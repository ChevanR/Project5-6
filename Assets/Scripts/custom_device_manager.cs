using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace HapE.Unity
{
    /// <summary>
    /// The Main interfce to the Hap-E Device. Handles connection and Playback.
    /// TODO: Split out the connection/playback logic
    /// </summary>
    /// 
    using Ultraleap.Haptics;
    using Leap.Unity;
    using System.Collections;

    public class CustomHapEDeviceManager : MonoBehaviour
    {
        [Header("Hap-e Device")]
        [Tooltip("If enabled, we attempt to connect to a device on startup")]
        public bool autoConnect = true;
        public Context ctx;

        [SerializeField]
        private List<DeviceInfo> availableDevices;
        public Device hapticDevice;
        public bool useMockIfRequired = true;

        [SerializeField]
        private bool _muteHaptics;

        [SerializeField]
        private float _softStartStopValue = 0f;
        public float SoftStartStopValue
        {
            get { return _softStartStopValue; }
            set { _softStartStopValue = Mathf.Clamp(value, 0.0f, 10f); }
        }

        [Tooltip("If true, haptic rendering will still occur, but not output any haptics. Useful for Demo mode.")]
        public bool MuteHaptics
        {
            get { return _muteHaptics; }
            set { SetHapticsMuteEnabled(value); }
        }

        public HapEParticleRenderer hapticRenderer;
        public LeapServiceProvider leapServiceProvider;

        // A bool which determines whether haptics should be updated every frame
        // (should be set to 'true' for anything that tracking the hand. 'false' if Fixed.
        [SerializeField]
        private bool _updateHaptics;
        public bool UpdateHaptics
        {
            get { return _updateHaptics; }
            set { _updateHaptics = value; }
        }

        [Header("Transforms")]
        [Tooltip("The Unity world space transform of the Haptic Array")]
        public Transform arrayTransform;
        private float[] previousTransform = new float[16];
        private float[] trackerTransform = new float[16];
        private TrackingOriginTransform trackingOriginTransform;
        private Vector3 defaultTrackerPosition = new Vector3(0, 0, 0.2f);

        [Header("Tracking")]
        public TrackingFixation trackTransformObject;
        public Transform trackerOrigin;
        public bool loadTrackerOriginFromJSON = true;

        
        
        // Start is called before the first frame update
        void Start()
        {
            if (arrayTransform == null)
            {
                arrayTransform = transform;
            }

            if (loadTrackerOriginFromJSON)
            {
                SetTrackingOriginFromJSON();
            }

            // Don't do anything if we don't want to auto-connect. Useful for multi-array configs.
            if (!autoConnect)
            {
                return;
            }

            ConnectToNewHapEDevice();
            if (hapticDevice == null)
            {
                Debug.LogWarning("Could not connect to phyiscal Hap-E device or create a MockDevice! Check Hap-e Plugins are up to date.");
            }

            // Set up Leap Listener to push tracking frame events to update the HapE Tracker Transform.
            if (leapServiceProvider == null)
            {
                leapServiceProvider = FindObjectOfType<LeapServiceProvider>();
            }
            leapServiceProvider.GetLeapController().FrameReady += FrameReady;

            // Start the custom coroutine
            StartCoroutine(RunCoroutine(0.01f));
        }

        private void FrameReady(object sender, Leap.FrameEventArgs e)
        {
            if (UpdateHaptics)
            {
                //Debug.Log($"FrameReady at Time {Time.time} with {e.frame.CurrentFramesPerSecond}");
                UpdateTrackerTransformFromNewLeapFrame();
            }
        }

        private void OnDisable()
        {
            if (hapticDevice != null && hapticDevice.HapE.IsSupported)
            {
                StopHaptics();
            }
            if (ctx != null)
            {
                //ctx.Dispose();
                ctx = null;
            }
        }

        #region Tracking
        // Main update loop updates the Hap-e Tracker Transform
        // Main update loop updates the Hap-e Tracker Transform
        void UpdateTrackerTransformFromNewLeapFrame()
        {
            if (trackTransformObject != null)
            {
                Quaternion rotation = trackTransformObject.transform.localRotation;
                Vector3 translation = trackTransformObject.transform.localPosition;
                SetTrackerTransform(rotation, translation);
            }
        }

        public void SetTrackerTransform(Quaternion rotation, Vector3 translation)
        {
            var hapticUnityLocalMatrix = Matrix4x4.TRS(translation, rotation, Vector3.one);
            var ulMatrix = UnityToHapticSpace.inverse * (hapticUnityLocalMatrix * UnityToHapticSpace);
            trackerTransform = ToFloatArray(ulMatrix);

            // Only update the Tracker if the Transform has changed, no point sending updates for fixed point haptics, only for hand tracked ones.
            if (!Enumerable.SequenceEqual(previousTransform, trackerTransform))
            {
                try
                {
                    hapticDevice.HapE.V3SetTracker(trackerTransform);
                    Array.Copy(trackerTransform, previousTransform, 16);
                }
                catch (Exception e)
                {
                    Debug.LogWarning(e);
                    Debug.LogWarning("Unable to update haptics.");
                    UpdateHaptics = false;
                }
            }
        }

        readonly Matrix4x4 UnityToHapticSpace = new Matrix4x4(new Vector4(1f, 0f, 0f, 0f),
                                                              new Vector4(0f, 0f, 1f, 0f),
                                                              new Vector4(0f, 1f, 0f, 0f),
                                                              new Vector4(0f, 0f, 0f, 1f));

        float[] ToFloatArray(Matrix4x4 inMatrix)
        {
            return new float[16]
            {
                inMatrix.m00, inMatrix.m01, inMatrix.m02, inMatrix.m03,
                inMatrix.m10, inMatrix.m11, inMatrix.m12, inMatrix.m13,
                inMatrix.m20, inMatrix.m21, inMatrix.m22, inMatrix.m23,
                inMatrix.m30, inMatrix.m31, inMatrix.m32, inMatrix.m33
            };
        }

        /// <summary>
        /// If requested, set the HandTracker Origin to load from JSON at runtime.
        /// </summary>
        private void SetTrackingOriginFromJSON()
        {
            trackingOriginTransform = new();
            string file = Path.Combine(Application.streamingAssetsPath, trackingOriginTransform.defaultTrackerOriginJSONFilename);
            if (!File.Exists(file))
            {
                Debug.LogWarning("Unable to detect a TrackerOrigin. Assuming Leap Tracker position is x=0,y=0,z=121");
            }
            else
            {
                string trackingOriginJSON = File.ReadAllText(file);
                trackingOriginTransform = JsonUtility.FromJson<TrackingOriginTransform>(trackingOriginJSON);
            }

            if (trackingOriginTransform.trackingPosition.Count == 3 && trackingOriginTransform.trackingRotation.Count == 3)
            {
                float xPos = trackingOriginTransform.trackingPosition[0];
                float yPos = trackingOriginTransform.trackingPosition[1];
                float zPos = trackingOriginTransform.trackingPosition[2];

                float xRot = trackingOriginTransform.trackingRotation[0];
                float yRot = trackingOriginTransform.trackingRotation[1];
                float zRot = trackingOriginTransform.trackingRotation[2];

                Vector3 pos = new Vector3(xPos, yPos, zPos);
                Quaternion rot = Quaternion.Euler(new Vector3(xRot, yRot, zRot));
                trackerOrigin.SetPositionAndRotation(pos, rot);
            }

            if (trackingOriginTransform.arrayPosition.Count == 3 && trackingOriginTransform.arrayRotation.Count == 3)
            {
                float xPos = trackingOriginTransform.arrayPosition[0];
                float yPos = trackingOriginTransform.arrayPosition[1];
                float zPos = trackingOriginTransform.arrayPosition[2];

                float xRot = trackingOriginTransform.arrayRotation[0];
                float yRot = trackingOriginTransform.arrayRotation[1];
                float zRot = trackingOriginTransform.arrayRotation[2];

                Vector3 pos = new Vector3(xPos, yPos, zPos);
                Quaternion rot = Quaternion.Euler(new Vector3(xRot, yRot, zRot));
                arrayTransform.SetPositionAndRotation(pos, rot);
            }
        }

        /// <summary>
        /// Set the default tracker transform (20 cm above array)
        /// </summary>
        public void SetDefaultTrackerTransform()
        {
            if (hapticDevice != null)
            {
                trackerTransform[0] = 1f;
                trackerTransform[3] = defaultTrackerPosition.x;
                trackerTransform[5] = 1f;
                trackerTransform[7] = defaultTrackerPosition.y;
                trackerTransform[10] = 1f;
                trackerTransform[11] = defaultTrackerPosition.z;
                trackerTransform[15] = 1f;
                hapticDevice.HapE.V3SetTracker(trackerTransform);
            }
        }

        public void SetHapEMasterVolume(float value)
        {
            if (hapticDevice != null)
            {
                Debug.Log("Setting Master volume to: " + value);
                hapticDevice.HapE.V3EnvelopeSetMasterVolume(value);
            }
        }

        #endregion
        #region Connection Handling

        /// <summary>
        /// Sets whether the device should FORCE use a Mock device, i.e. not output
        /// haptics, but still do evaluation, with a Mock device, (for visualisation purposes).
        /// </summary>
        /// <param name="muted"></param>
        public void SetHapticsMuteEnabled(bool muted)
        {
            _muteHaptics = muted;
            if (muted)
            {
                if (!UsingMockHapEDevice())
                {
                    StopHaptics();
                    hapticDevice = ctx.CreateMockDevice();
                }
            }
            else
            {
                if (UsingMockHapEDevice())
                {
                    // Try and get a real device...
                    ConnectToNewHapEDevice();
                }
            }
        }

        public bool UsingMockHapEDevice()
        {
            if (hapticDevice == null)
            {
                return false;
            }
            return hapticDevice.GetType() == typeof(MockDevice);
        }

        public List<DeviceInfo> GetConnectedDevices()
        {
            if (ctx == null)
            {
                ctx = new Context();
            }
            return ctx.GetConnectedDevices();
        }

        /// <summary>
        /// Returns the number of currently connected Haptic Devices
        /// </summary>
        /// <returns></returns>
        public int GetDeviceCount()
        {
            return GetConnectedDevices().Count;
        }

        public Device ConnectToNewHapEDevice()
        {
            if (ctx == null)
            {
                ctx = new Context();
            }

            availableDevices = GetConnectedDevices();
            // Ensure haptics are not playing!
            StopHaptics();

            if (availableDevices.Count == 0)
            {
                if (hapticDevice != null)
                {
                    hapticDevice.Dispose();
                    hapticDevice = null;
                }

                if (useMockIfRequired && !UsingMockHapEDevice())
                {
                    hapticDevice = ctx.CreateMockDevice();
                }

                // Return now, because no phyiscal devices were detected.
                return null;
            }

            // If we're here, we might have already created a MockDevice, so get rid of it first and stop if playing..
            if (hapticDevice != null)
            {
                hapticDevice.Dispose();
                hapticDevice = null;
            }

            foreach (DeviceInfo di in availableDevices)
            {
                try
                {
                    // Get the first connected device...
                    hapticDevice = di.Open();
                    string deviceInfo = GetInfoStringForDevice(hapticDevice);
                    Debug.Log(deviceInfo);
                    break;
                }
                catch (Exception e)
                {
                    Debug.Log("Exception: " + e.ToString());
                }
            }
            return hapticDevice;
        }

        public string HapEDeviceConnectionStatusString()
        {
            string connectionStatusString = "Connection unavailable";
            if (hapticDevice != null)
            {
                string hardwareFirmware = GetFirmwareString();
                connectionStatusString = $"Connected to Hap-E Device:\n {hapticDevice.Identifier} \n Firmware: {hardwareFirmware}";
            }
            return connectionStatusString;
        }

        /// <summary>
        /// This is the Firmware String we use in the Sensation Designer array connection tooltip.
        /// </summary>
        /// <returns></returns>
        public string GetFirmwareString()
        {
            string firmwareString = "Unknown";
            if (hapticDevice != null)
            {
                try
                {
                    var firmwareVersions = hapticDevice.getFirmwareVersions();
                    firmwareString = $"{firmwareVersions.HapticsApp.Major}.{firmwareVersions.HapticsApp.Minor}.{firmwareVersions.HapticsApp.Patch}";
                }
                catch (Exception e)
                {
                    Debug.LogWarning($"Unable to obtain firmware version: {e}");
                }
            }

            return firmwareString;
        }

        public void CopyAllHardwareInfoToClipboard()
        {
            if (hapticDevice != null)
            {
                string hardwareInfoString = GetInfoStringForDevice(hapticDevice);
                hardwareInfoString.CopyToClipboard();
            }
        }


        /// <summary>
        /// Returns a string of all the available Hardware info (firmware etc.) about the Hap-e Device.
        /// </summary>
        /// <returns></returns>
        public string GetInfoStringForDevice(Device device)
        {
            string deviceInfo = "Ultraleap Hap-e Device Info\n" +
                $"Identifier: {hapticDevice.Identifier}\n";
            if (device != null)
            {
                try
                {
                    var firmwareVersions = device.getFirmwareVersions();
                    var hapticsApp = firmwareVersions.HapticsApp;
                    var bootloader = firmwareVersions.Bootloader;
                    var dfu = firmwareVersions.DFUFlashloader;
                    var hardware = firmwareVersions.HardwareVersion;
                    var fpgaProgram = firmwareVersions.FPGAProgrammer;
                    var fpgaSolver = firmwareVersions.FPGASolver;

                    deviceInfo += $"HapticsApp: {hapticsApp.Major}.{hapticsApp.Minor}.{hapticsApp.Patch} (#{hapticsApp.GitHash.HashAsHex()}, Dirty={hapticsApp.Dirty}, Valid={hapticsApp.Valid})\n" +
                        $"Bootloader: {bootloader.Major}.{bootloader.Minor}.{bootloader.Patch} (#{bootloader.GitHash.HashAsHex()}, Dirty={bootloader.Dirty}, Valid={bootloader.Valid})\n" +
                        $"DFUFlashloader: {dfu.Major}.{dfu.Minor}.{dfu.Patch} (#{dfu.GitHash.HashAsHex()}, Dirty={dfu.Dirty}, Valid={dfu.Valid})\n" +
                        $"HardwareVersion: {hardware.Major}.{hardware.Minor}.{hardware.Patch} (#{hardware.GitHash.HashAsHex()}, Dirty={hardware.Dirty}, Valid={hardware.Valid})\n" +
                        $"FPGAProgrammer: {fpgaProgram.Major}.{fpgaProgram.Minor}.{fpgaProgram.Patch} (#{fpgaProgram.GitHash.HashAsHex()}, Dirty={fpgaProgram.Dirty}, Valid={fpgaProgram.Valid})\n" +
                        $"FPGASolver: {fpgaSolver.Major}.{fpgaSolver.Minor}.{fpgaSolver.Patch} (#{fpgaSolver.GitHash.HashAsHex()}, Dirty={fpgaSolver.Dirty}, Valid={fpgaSolver.Valid})\n";
                }
                catch (Exception e)
                {
                    Debug.LogWarning($"Unable to obtain firmware version: {e}");
                }
            }

            return deviceInfo;
        }


        #endregion
        #region Playback

        /// <summary>
        /// Plays a Hap-E json file, as defined by the jsonPath
        /// </summary>
        /// <param name="jsonPath"></param>
        public void PlayHapEJSON(string jsonPath)
        {
            if (hapticDevice == null)
            {
                Debug.LogWarning("Unable to Play HapEJSON, no valid hapticDevice available!");
                return;
            }

            if (File.Exists(jsonPath))
            {
                UpdateHaptics = true;
                hapticDevice.HapE.V3LoadJSONFile(jsonPath);
                hapticDevice.HapE.Start(softValue: SoftStartStopValue);
            }
            else
            {
                Debug.LogWarning("JSON Path could not be found:" + jsonPath);
            }
        }

        public void PlayHapEJSONOnDevice(string jsonPath, Device hapeDevice)
        {
            if (hapeDevice == null || !hapeDevice.IsConnected || !hapeDevice.HapE.IsSupported)
            {
                Debug.LogWarning("Unable to Play HapEJSON, no valid hapticDevice available!");
                return;
            }

            if (File.Exists(jsonPath))
            {
                UpdateHaptics = true;
                hapeDevice.HapE.V3LoadJSONFile(jsonPath);
                hapeDevice.HapE.Start(softValue: SoftStartStopValue);
            }
            else
            {
                Debug.LogWarning("JSON Path could not be found:" + jsonPath);
            }
        }

       

        /// <summary>
        /// Plays a Hap-E haptic definition from a string containing the Hap-e JSON contents.
        /// </summary>
        /// <param name="jsonPath"></param>
        public void PlayHapEJSONString(string jsonString)
        {
            if (hapticDevice == null)
            {
                Debug.LogWarning("Unable to Play HapEJSON, no valid hapticDevice available!");
                return;
            }
            UpdateHaptics = true;
            hapticDevice.HapE.V3LoadJSONString(jsonString);
            hapticDevice.HapE.Start(softValue: SoftStartStopValue);
        }

        public void SetHapEPlaybackMode(int playbackMode)
        {
            // 0=Forward, 1=Backward, 2=PingPong, 3=Random
            StopHaptics();
            hapticDevice.HapE.V3PainterSetMode((HapE.V3PainterMode)(byte)playbackMode);
            hapticDevice.HapE.V3EnvelopeSetMode((HapE.V3EnvelopeMode)(byte)playbackMode);
        }

        public virtual void StopHaptics()
        {
            UpdateHaptics = false;
            hapticRenderer.ClearParticles();

            // We have to wrap this in a try catch, because if the device gets disconnected,
            // there's no signal to allow us to null the hapticDevice.
            try
            {
                hapticDevice?.HapE.Stop();
            }
            catch (Exception e)
            {
                Debug.LogWarning($"Error Stopping {hapticDevice}. Message = {e.Message}");
                Debug.LogWarning("Unable to Stop Haptics... Was the device disconnected?");
            }
        }

        public void PlayStaticPointFromHapEData(HapEData hapEData)
        {
            // Set Primitive Params
            SetPrimitivePropertiesFromHapEData(hapEData);
            hapticDevice.HapE.V3SendCommand(HapE.V3Command.EnablePainter, 1);

            PainterNode point;
            if (hapEData.painter == null || hapEData.painter.nodes == null)
            {
                Debug.LogWarning("No Node data existed in hapEData! Assuming point at 0,0");
                point.x = 0f;
                point.y = 0f;
                point.x_scale = 1f;
                point.y_scale = 1f;
                point.z_rotation = 0;
            }
            else
            {
                point = hapEData.painter.nodes[0];
            }
            hapticDevice.HapE.V3PainterUpdateNode(0, point.x, point.y, point.z_rotation, point.x_scale, point.y_scale, 1f);
            hapticDevice.HapE.V3PainterUpdateNode(1, point.x, point.y, point.z_rotation, point.x_scale, point.y_scale, 1f);
            hapticDevice.HapE.V3PainterSetLength(1);
            hapticDevice.HapE.V3PainterSetRepeatCount(0);
            SetEnvelopeNodesFromHapEData(hapEData);

            if (hapEData.animator != null && hapEData.animator.enabled)
            {
                SetAnimatorTransformsFromHapEData(hapEData);
                hapticDevice.HapE.V3SendCommand(HapE.V3Command.EnableAnimator, 1);
            }
            else
            {
                hapticDevice.HapE.V3SendCommand(HapE.V3Command.EnableAnimator, 0);
            }

            if (!UpdateHaptics)
            {
                hapticDevice.HapE.Start(softValue: SoftStartStopValue);
            }
            UpdateHaptics = true;
            return;
        }


        public void SetPlaybackRepeatCount(int repeatCount)
        {
            if (hapticDevice == null)
            {
                return;
            }
            hapticDevice.HapE.V3PainterSetRepeatCount((uint)repeatCount);
            hapticDevice.HapE.V3EnvelopeSetRepeatCount((uint)repeatCount);
        }
        #endregion
        #region HapE Data Handling
        public void ResetHapEState()
        {
            hapticDevice?.HapE.V3ResetToDefault();
        }

        public bool HapEDeviceAvailable()
        {
            return (hapticDevice != null);// (hapticDevice != null && ((GetConnectedDevices().Count) > 0 || UsingMockHapEDevice()));
        }

        /// <summary>
        /// Sets all Primitive Properties, stored in hapEData
        /// </summary>
        /// <param name="hapEData"></param>
        public void SetPrimitivePropertiesFromHapEData(HapEData hapEData)
        {
            if (!HapEDeviceAvailable())
            {
                return;
            }

            if (hapEData.primitive != null)
            {
                PrimitiveProperties primitiveProperties = hapEData.primitive;
                float f = primitiveProperties.draw_frequency;
                float A = primitiveProperties.A;
                float B = primitiveProperties.B;
                hapticDevice.HapE.V3PrimitiveSetParameter(HapE.V3PrimitiveParameter.DrawFrequency, f);
                hapticDevice.HapE.V3PrimitiveSetParameter(HapE.V3PrimitiveParameter.BigA, A);
                hapticDevice.HapE.V3PrimitiveSetParameter(HapE.V3PrimitiveParameter.BigB, B);
                hapticDevice.HapE.V3PrimitiveSetParameter(HapE.V3PrimitiveParameter.a, (float)primitiveProperties.a);
                hapticDevice.HapE.V3PrimitiveSetParameter(HapE.V3PrimitiveParameter.b, (float)primitiveProperties.b);

                // These properties are not always set in our DefaultBrush Assets, hence they could be null/NaN
                // TODO: Include null checks for every property, to be safe?...
                if ((primitiveProperties.max_t != null) && !float.IsNaN(primitiveProperties.max_t.Value))
                {
                    hapticDevice.HapE.V3PrimitiveSetParameter(HapE.V3PrimitiveParameter.MaxT, (float)primitiveProperties.max_t);
                }
                if ((primitiveProperties.k != null) && !float.IsNaN(primitiveProperties.k.Value))
                {
                    hapticDevice.HapE.V3PrimitiveSetParameter(HapE.V3PrimitiveParameter.k, (float)primitiveProperties.k);
                }
                if ((primitiveProperties.d != null) && !float.IsNaN(primitiveProperties.d.Value))
                {
                    hapticDevice.HapE.V3PrimitiveSetParameter(HapE.V3PrimitiveParameter.d, (float)primitiveProperties.d);
                }
            }
            else
            {
                Debug.LogWarning("HapEData had no valid Primitive Data set!");
            }
        }

        /// <summary>
        /// Sets All Primitive Parameters froma a HapEBrush scriptable object
        /// </summary>
        /// <param name="brush"></param>
        public void SetPrimitivePropertiesFromHapEBrushDefault(HapEBrushDefault brush)
        {
            foreach (HapEBrushDefault.HapEPrimitiveParameter P in brush.primitiveParams)
            {
                hapticDevice.HapE.V3PrimitiveSetParameter(P.parameter, P.value);
            }
        }

        /// <summary>
        /// Loads HapEData onto the device. Does not play back.
        /// </summary>
        /// <param name="hapEData"></param>

        public void LoadHapEData(HapEData hapEData, bool skipReset = false)
        {
            if (!skipReset)
            {
                ResetHapEState();
            }

            if (hapEData.animator != null)
            {
                SetAnimatorTransformsFromHapEData(hapEData);
            }

            if (hapEData.primitive != null)
            {
                SetPrimitivePropertiesFromHapEData(hapEData);
            }

            if (hapEData.painter != null)
            {
                UpdatePainterNodesFromHapEData(hapEData);
            }
            if (hapEData.envelope != null)
            {
                SetEnvelopeNodesFromHapEData(hapEData);
            }
        }


        /// <summary>
        /// Plays back a Hap-e Sensation from HapEData Object, typically derived from Hap-e JSON.
        /// </summary>
        /// <param name="hapEData"></param>
        public void PlayHapEData(HapEData hapEData, bool skipReset = false)
        {
            LoadHapEData(hapEData, skipReset: skipReset);
            UpdateHaptics = true;
            if (hapticDevice != null)
            {
                hapticDevice.HapE.Start(softValue: SoftStartStopValue);
            }
        }

        /// <summary>
        /// Plays back a Hap-e Sensation from HapEData Object, typically derived from Hap-e JSON,
        /// Allows override of the soft start stop value.
        /// </summary>
        /// <param name="hapEData"></param>
        public void PlayHapEDataWithSoftStartStop(HapEData hapEData, bool skipReset = false, float softValue = 0.0f)
        {
            LoadHapEData(hapEData, skipReset: skipReset);
            UpdateHaptics = true;
            if (hapticDevice != null)
            {
                hapticDevice.HapE.Start(softValue: SoftStartStopValue);
            }
        }


        /// <summary>
        /// Just plays back what ever is the current Hap-E Data on the device, tracking updates stil occur
        /// </summary>
        /// <param name="hapEData"></param>
        public void PlayCurrentDeviceHapEData()
        {
            if (hapticDevice != null)
            {
                UpdateHaptics = true;
                hapticDevice.HapE.Start(softValue: SoftStartStopValue);
            }
        }

        /// <summary>
        /// Updates the Painter Nodes on device from HapeData Object
        /// </summary>
        /// <param name="hapEData"></param>
        public void UpdatePainterNodesFromHapEData(HapEData hapEData)
        {
            if (hapticDevice == null)
            {
                return;
            }

            PainterProperties painterProperties = hapEData.painter;
            if (painterProperties == null || !hapEData.painter.enabled)
            {
                hapticDevice.HapE.V3SendCommand(HapE.V3Command.EnablePainter, 0);
                return;
            }

            uint numPoints = (uint)painterProperties.nodes.Count;

            if (numPoints == 1 && UpdateHaptics)
            {
                PlayStaticPointFromHapEData(hapEData);
                return;
            }


            int painterRepeatCount = (int)painterProperties.repeat_count;
            HapE.V3PainterMode painterMode = painterProperties.PainterMode();
            hapticDevice.HapE.V3SendCommand(HapE.V3Command.EnablePainter, 1);
            List<PainterNode> painterNodes = painterProperties.nodes;

            for (int ix = 0; ix < numPoints; ix++)
            {
                PainterNode pt = painterNodes[ix];
                uint nodeId = (uint)(ix);
                //Debug.Log("Setting painter node:" + nodeId + ", time: " + pt.t + ", x: " + pt.x + ", y:" + pt.y);
                hapticDevice.HapE.V3PainterUpdateNode(nodeId, pt.x, pt.y, pt.z_rotation, pt.x_scale, pt.y_scale, pt.t);
            }
            hapticDevice.HapE.V3PainterSetMode(painterMode);
            hapticDevice.HapE.V3PainterSetLength(numPoints);
            hapticDevice.HapE.V3PainterSetRepeatCount((uint)painterRepeatCount);
        }

        public void SetEnvelopeNodesFromHapEData(HapEData hapEData)
        {
            if (hapticDevice == null)
            {
                return;
            }
            EnvelopeProperties envelopeProperties = hapEData.envelope;
            if (envelopeProperties == null || !hapEData.envelope.enabled)
            {
                hapticDevice.HapE.V3SendCommand(HapE.V3Command.EnableEnvelope, 0);
                return;
            }

            List<EnvelopeNode> envelopeNodes = envelopeProperties.nodes;
            uint envelopeLength = (uint)envelopeNodes.Count;
            hapticDevice.HapE.V3SendCommand(HapE.V3Command.EnableEnvelope, 1);
            for (int ix = 0; ix < envelopeLength; ix++)
            {
                uint nodeId = (uint)(ix);
                float intensity = envelopeNodes[ix].intensity;
                float time = envelopeNodes[ix].t;
                //Debug.Log("Setting envelope node ID: " + nodeId + ", intensity:" + intensity + ", time: " + time);
                hapticDevice.HapE.V3EnvelopeUpdateNode(nodeId, intensity, time);
            }

            // Envelope Settings
            int envelopeRepeatCount = (int)envelopeProperties.repeat_count;
            hapticDevice.HapE.V3EnvelopeSetLength((uint)envelopeLength);
            // This sets the number of times the envelope repeats, 0 means it loops infinitely
            hapticDevice.HapE.V3EnvelopeSetRepeatCount((uint)envelopeRepeatCount);
            HapE.V3EnvelopeMode envelopeMode = envelopeProperties.EnvelopeMode();
            hapticDevice.HapE.V3EnvelopeSetMode(envelopeMode);
        }

        public void SetAnimatorTransformsFromHapEData(HapEData hapEData)
        {
            //Debug.Log("HapeDeviceManager: SetAnimatorTransformsFromHapEData");

            if (hapticDevice == null)
            {
                return;
            }

            if (hapEData.animator == null || !hapEData.animator.enabled)
            {
                //Debug.Log("Disabling Animator");
                hapticDevice.HapE.V3SendCommand(HapE.V3Command.EnableAnimator, 0);
                return;
            }

            hapticDevice.HapE.V3SendCommand(HapE.V3Command.EnableAnimator, 1);
            if (hapEData.animator.T1 != null && hapEData.animator.T1.Length > 0)
            {
                hapticDevice.HapE.V3AnimatorSetTransform(HapE.V3AnimatorTransform.T1, hapEData.animator.T1);
            }
            if (hapEData.animator.T1a1 != null && hapEData.animator.T1a1.Length > 0)
            {
                hapticDevice.HapE.V3AnimatorSetTransform(HapE.V3AnimatorTransform.T1A1, hapEData.animator.T1a1);
            }
            if (hapEData.animator.T1a2 != null && hapEData.animator.T1a2.Length > 0)
            {
                hapticDevice.HapE.V3AnimatorSetTransform(HapE.V3AnimatorTransform.T1A2, hapEData.animator.T1a2);
            }
            if (hapEData.animator.T2 != null && hapEData.animator.T2.Length > 0)
            {
                hapticDevice.HapE.V3AnimatorSetTransform(HapE.V3AnimatorTransform.T2, hapEData.animator.T2);
            }
            if (hapEData.animator.T2a1 != null && hapEData.animator.T2a1.Length > 0)
            {
                hapticDevice.HapE.V3AnimatorSetTransform(HapE.V3AnimatorTransform.T2A1, hapEData.animator.T2a1);
            }
            if (hapEData.animator.T2a2 != null && hapEData.animator.T2a2.Length > 0)
            {
                hapticDevice.HapE.V3AnimatorSetTransform(HapE.V3AnimatorTransform.T2A2, hapEData.animator.T2a2);
            }
            if (hapEData.animator.T1a1_switch_count != 0)
            {
                hapticDevice.HapE.V3SendCommand(HapE.V3Command.T1A1SwitchCount, (uint)hapEData.animator.T1a1_switch_count);
            }
            if (hapEData.animator.T1a2_switch_count != 0)
            {
                hapticDevice.HapE.V3SendCommand(HapE.V3Command.T1A2SwitchCount, (uint)hapEData.animator.T1a2_switch_count);
            }
            if (hapEData.animator.T2a1_switch_count != null)
            {
                hapticDevice.HapE.V3SendCommand(HapE.V3Command.T2A1SwitchCount, (uint)hapEData.animator.T2a1_switch_count.Value);
            }
            if (hapEData.animator.T2a2_switch_count != null)
            {
                hapticDevice.HapE.V3SendCommand(HapE.V3Command.T2A2SwitchCount, (uint)hapEData.animator.T2a2_switch_count.Value);
            }
        }
        #endregion

        /// <summary>
        /// CUSTOM Code below here
        /// </summary>
        /// 
        Dictionary<int, Tuple<Vector2, bool>> items = new Dictionary<int, Tuple<Vector2, bool>>();
        [SerializeField] float delay_in_seconds = 0.0f;

        // Coroutine that checks if the palm it hitting the object to play haptic feedback
        private IEnumerator RunCoroutine(float interval)
        {
            // Finger haptic feedback json
            //string json
            //    = "{\r\n  \"version\": 2,\r\n  \"format_version\": 1,\r\n  \"primitive\": {\r\n    \"draw_frequency\": 127,\r\n    \"A\": 0.01,\r\n    \"B\": 0.01,\r\n    \"a\": 1.0,\r\n    \"b\": 1.0,\r\n    \"max_t\": 6.28318548,\r\n    \"d\": 1.57079637,\r\n    \"k\": 0.0\r\n  },\r\n  \"animator\": {\r\n    \"enabled\": false,\r\n    \"T1a1_switch_count\": 0,\r\n    \"T1a2_switch_count\": 0\r\n  },\r\n  \"envelope\": {\r\n    \"enabled\": true,\r\n    \"nodes\": [\r\n      {\r\n        \"intensity\": 1.0,\r\n        \"t\": 0.01\r\n      },\r\n      {\r\n        \"intensity\": 1.0,\r\n        \"t\": 0.0\r\n      }\r\n    ],\r\n    \"mode\": 1,\r\n    \"length\": 2,\r\n    \"repeat_count\": 0\r\n  },\r\n  \"painter\": {\r\n    \"enabled\": true,\r\n    \"nodes\": [\r\n      {\r\n        \"x\": 0.00233333115,\r\n        \"y\": -0.02663334,\r\n        \"z_rotation\": 0.0,\r\n        \"x_scale\": 1.0,\r\n        \"y_scale\": 1.0,\r\n        \"t\": 0.01\r\n      },\r\n      {\r\n        \"x\": 0.00200001,\r\n        \"y\": 0.0616999753,\r\n        \"z_rotation\": 0.0,\r\n        \"x_scale\": 1.0,\r\n        \"y_scale\": 1.0,\r\n        \"t\": 0.0\r\n      }\r\n    ],\r\n    \"mode\": 1,\r\n    \"length\": 2,\r\n    \"repeat_count\": 0\r\n  },\r\n  \"fixation_mode\": 0,\r\n  \"fixation_offset\": {\r\n    \"x\": 0.0,\r\n    \"y\": 0.0,\r\n    \"z\": 0.0,\r\n    \"magnitude\": 0.0,\r\n    \"sqrMagnitude\": 0.0\r\n  },\r\n  \"hapticName\": \"NewHaptic\",\r\n  \"brushName\": \"Circle\"\r\n}";

            Boolean last_palm = false;
            while (true) // Infinite loop
            {
                // Create a copy of the dictionary for safe iteration
                Dictionary<int, Tuple<Vector2, bool>> _items = new Dictionary<int, Tuple<Vector2, bool>>(items);
                Boolean check = false;

                if ((_items.ContainsKey(69) && _items[69].Item2))
                {
                    check = true;
                    if (!last_palm)
                    {
                        Debug.Log("Palm start");
                        StopHaptics();
                        PlayHapEJSON("Assets/Resources/json/palm.json");
                    }
                    last_palm = true;
                    yield return new WaitForSeconds(interval * 0.01f);
                    yield return new WaitForSeconds(delay_in_seconds);
                }
                else
                {
                    if (last_palm)
                    {
                        last_palm = false;
                        Debug.Log("Palm stop");
                        StopHaptics();
                    }

                    // // Finger haptic feedback
                    //foreach (KeyValuePair<int, Tuple<Vector2, bool>> entry in _items)
                    //{
                    //    // Extract the Vector2 and Boolean from the Tuple
                    //    Vector2 position = entry.Value.Item1;
                    //    bool isActive = entry.Value.Item2;

                    //    // Process only active entries
                    //    if (isActive)
                    //    {
                    //        check = true;
                    //        StopHaptics();
                    //        // Call your processing method with the position values
                    //        PlayXYJSON(position.x, position.y, json);
                    //        //Debug.Log($"Processed active item with ID: {entry.Key}, X: {position.x}, Y: {position.y}");
                    //    }

                    //    // Wait for the specified delay before processing the next value
                    //    yield return new WaitForSeconds(interval * 8);
                    //}
                }
                //ResetHapEState();
                if (!check) StopHaptics();
                // Wait for the specified interval before looping again
                yield return new WaitForSeconds(interval * 0.01f);
            }
        }

        // Function to play haptic feedback at x,y coord using json as string
        public void PlayXYJSON(float x, float y, string json)
        {
            // Load default json if not given
            if (string.IsNullOrEmpty(json)) {
                json ="{\r\n  \"version\": 2,\r\n  \"format_version\": 1,\r\n  \"primitive\": {\r\n    \"draw_frequency\": 127,\r\n    \"A\": 0.01,\r\n    \"B\": 0.01,\r\n    \"a\": 1.0,\r\n    \"b\": 1.0,\r\n    \"max_t\": 6.28318548,\r\n    \"d\": 1.57079637,\r\n    \"k\": 0.0\r\n  },\r\n  \"animator\": {\r\n    \"enabled\": false,\r\n    \"T1a1_switch_count\": 0,\r\n    \"T1a2_switch_count\": 0\r\n  },\r\n  \"envelope\": {\r\n    \"enabled\": true,\r\n    \"nodes\": [\r\n      {\r\n        \"intensity\": 1.0,\r\n        \"t\": 0.01\r\n      },\r\n      {\r\n        \"intensity\": 1.0,\r\n        \"t\": 0.0\r\n      }\r\n    ],\r\n    \"mode\": 1,\r\n    \"length\": 2,\r\n    \"repeat_count\": 0\r\n  },\r\n  \"painter\": {\r\n    \"enabled\": true,\r\n    \"nodes\": [\r\n      {\r\n        \"x\": 0.00233333115,\r\n        \"y\": -0.02663334,\r\n        \"z_rotation\": 0.0,\r\n        \"x_scale\": 1.0,\r\n        \"y_scale\": 1.0,\r\n        \"t\": 0.01\r\n      },\r\n      {\r\n        \"x\": 0.00200001,\r\n        \"y\": 0.0616999753,\r\n        \"z_rotation\": 0.0,\r\n        \"x_scale\": 1.0,\r\n        \"y_scale\": 1.0,\r\n        \"t\": 0.0\r\n      }\r\n    ],\r\n    \"mode\": 1,\r\n    \"length\": 2,\r\n    \"repeat_count\": 0\r\n  },\r\n  \"fixation_mode\": 0,\r\n  \"fixation_offset\": {\r\n    \"x\": 0.0,\r\n    \"y\": 0.0,\r\n    \"z\": 0.0,\r\n    \"magnitude\": 0.0,\r\n    \"sqrMagnitude\": 0.0\r\n  },\r\n  \"hapticName\": \"NewHaptic\",\r\n  \"brushName\": \"Circle\"\r\n}";
            }

            JObject jsonObject = JObject.Parse(json);
            JArray nodes = (JArray)jsonObject["painter"]["nodes"];
            if (nodes.Count > 0)
            {
                JObject firstNode = (JObject)nodes[0];
                firstNode["x"] = x;
                firstNode["y"] = y;
                JObject sNode = (JObject)nodes[1];
                sNode["x"] = x;
                sNode["y"] = y;
            }
            string updatedJson = jsonObject.ToString(Formatting.Indented);
            hapticDevice.HapE.V3LoadJSONString(updatedJson);
            hapticDevice.HapE.Start();
        }

        // Add or update an entry in the dictionary
        public void UpdateValue(int id, Vector2 value)
        {
            if (id == 0) return; // Ignore ID 0

            if (!items.ContainsKey(id))
            {
                // Add a new entry if it doesn't exist
                items.Add(id, new Tuple<Vector2, bool>(value, false));
            }
            else
            {
                // Update the existing entry
                items[id] = new Tuple<Vector2, bool>(value, items[id].Item2);
            }
        }

        // Enable an item (set its active state to true)
        public void Enable(int id)
        {
            if (id == 0) return; // Ignore ID 0

            if (items.ContainsKey(id))
            {
                // Retrieve the current Vector2 value
                Vector2 currentVector = items[id].Item1;

                // Replace the entry with a new Tuple, setting the bool to true
                items[id] = new Tuple<Vector2, bool>(currentVector, true);
            }
            else
            {
                // Optionally handle cases where the item does not exist
                Debug.LogWarning($"Item with ID {id} does not exist.");
            }
        }

        // Disable (deactivate) an item (set its active state to false)
        public void Disable(int id)
        {
            if (id == 0) return; // Ignore ID 0

            if (items.ContainsKey(id))
            {
                // Retrieve the current Vector2 value
                Vector2 currentVector = items[id].Item1;

                // Replace the entry with a new Tuple, setting the bool to false
                items[id] = new Tuple<Vector2, bool>(currentVector, false);
            }
            else
            {
                // Optionally handle cases where the item does not exist
                Debug.LogWarning($"Item with ID {id} does not exist.");
            }
        }

        // Function to do haptic at specific coord without json (does not work)
        //public void PlayStaticPointAtCoordinates(float x, float y)
        //{
        //    ResetHapEState();

        //    // HapEData
        //    HapEData data = new();

        //    // Primitive
        //    data.primitive = new()
        //    {
        //        A = 0.01f,
        //        B = 0.01f,
        //        a = 1,
        //        b = 1,
        //        max_t = 6.28318548f,
        //        d = 1.5707963f,
        //        k = 0,
        //        draw_frequency = 127
        //    };


        //    // Animator
        //    data.animator = new()
        //    {
        //        enabled = false,
        //        T1a1_switch_count = 0,
        //        T1a2_switch_count = 0
        //    };

        //    // Painter
        //    hapticDevice.HapE.V3SendCommand(HapE.V3Command.EnablePainter, 1);
        //    PainterNode point;
        //    point.x = x;
        //    point.y = y;
        //    point.x_scale = 1f;
        //    point.y_scale = 1f;
        //    point.z_rotation = 0;

        //    hapticDevice.HapE.V3PainterUpdateNode(0, point.x, point.y, point.z_rotation, point.x_scale, point.y_scale, 1f);
        //    hapticDevice.HapE.V3PainterSetLength(1);
        //    hapticDevice.HapE.V3PainterSetRepeatCount(0);
        //    hapticDevice.HapE.V3PainterSetMode(0);

        //    // Envelope

        //    data.envelope = new()
        //    {
        //        nodes = new(),
        //        enabled = true
        //    };

        //    EnvelopeNode node = new()
        //    {
        //        t = 1.0f,
        //        intensity = 1.0f
        //    };
        //    data.envelope.nodes.Add(node);

        //    EnvelopeNode node2 = new()
        //    {
        //        t = 0.0f,
        //        intensity = 1.0f
        //    };
        //    data.envelope.nodes.Add(node2);

        //    data.envelope.mode = 0;
        //    data.envelope.length = 2;
        //    data.envelope.repeat_count = 0;

        //    // Fixation
        //    data.fixation_mode = 0;
        //    data.fixation_offset = new()
        //    {
        //        x = 0.0f,
        //        y = 0.0f,
        //        z = 0.0f
        //    };


        //    data.hapticName = "CUSTOM";
        //    data.brushName = "Circle";

        //    SetEnvelopeNodesFromHapEData(data);
        //    SetAnimatorTransformsFromHapEData(data);
        //    SetPrimitivePropertiesFromHapEData(data);

        //    hapticDevice.HapE.Start(softValue: SoftStartStopValue);
        //}

    }
}