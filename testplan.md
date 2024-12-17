# TESTPLAN  

## Necessities  

### VR  
1. Laptop/Computer  
2. ALVR  
3. VR compatible device  
4. SteamVR  
5. Test World (Unity)  

### Network  
1. Clumsy  
2. Unity C# script  

### Haptic  
1. Ultraleap Haptic Device  
2. Compatible Unity test environment  

### Logging & Experience  
[VR](#VR), [Haptic](#Haptic), and [Network](#Network)  
1. Python scripts  
2. Questionnaire  

---

## Requirements  

1. **VR Application Development**  
2. **Use an actual VR headset for the application**  
3. **Remote Rendering Implementation**  
4. **Network Degradation Simulation**  
5. **Performance Data Logging**  
6. **Data Analysis**  
7. **MVP Creation for Stakeholders**  
8. **Iterate Based on Feedback**  
9. **Multiplayer Feature Implementation**  
10. **Test with Diverse User Groups**  
11. **Allow the usage for different VR headsets**  
12. **Usage of a dedicated server**  
13. **Users can connect from all over the world**  
14. **Users get haptic feedback**  
15. **Clients identification**  
16. **Haptic controls map movement**  
17. **Client needs to go between 1st and 3rd person**  
18. **1st and 3rd person needs to be done with gestures (haptic)**  
19. **Client communication via microphone**  
20. **Haptic & VR user experience**  

---

## Testing  

### VR Application Development  
#### Test Purpose  
To ensure the VR device functions correctly with remote rendering and updates in real time.  

#### Necessities  
[VR](#VR)  

#### Steps  
1. Press **Play** in Unity.  
2. Connect the VR device via ALVR.  
3. Move the VR headset and observe if the camera in the game updates in real-time.  
4. Use the controllers to interact with the test environment.  

#### Results  
✅ **Observed**: The VR camera followed the head movements accurately, and controller interactions updated the environment on screen.  
❌ **Issues**: None observed.  

---

### Use an Actual VR Headset for the Application  
#### Test Purpose  
To verify that the VR device controls the camera and no other inputs interfere.  

#### Necessities  
[VR](#VR)  

#### Steps  
1. Press **Play** in Unity.  
2. Move the VR headset and observe if the camera follows the same movement in-game.  
3. Test movements on both axes: horizontal and vertical.  

#### Results  
✅ **Observed**: Moving the VR headset updated the camera position on all axes with no lag.  
❌ **Issues**: None noted during testing.  

---

### Remote Rendering Implementation  
#### Test Purpose  
To ensure that the game continues rendering remotely even when the VR headset disconnects.  

#### Necessities  
[VR](#VR)  

#### Steps  
1. Press **Play** in Unity and start remote rendering via ALVR.  
2. Disconnect the VR headset temporarily.  
3. Observe if the game continues running and rendering on the laptop.  

#### Results  
✅ **Observed**: The game continued rendering smoothly on the laptop despite VR headset disconnection.  
❌ **Issues**: Small visual hiccup for 1-2 seconds after disconnecting the VR device.  

---

### Network Degradation Simulation  
#### Test Purpose  
To evaluate how network latency affects VR performance during remote rendering.  

#### Necessities  
[VR](#VR), [Network](#Network)  

#### Steps  
1. Start the test world in Unity and connect the VR headset.  
2. Use **Clumsy** to simulate network latency increments of **50ms**, **100ms**, **150ms**, and **200ms**.  
3. Move the VR headset and observe delays in visual feedback.  
4. Record user feedback on usability and performance at each latency level.  

#### Results  
| **Latency (ms)** | **Visual Delay (ms)** | **User Feedback**                  |  
|------------------|-----------------------|------------------------------------|  
| 50               | ~52                  | "Slight delay, barely noticeable." |  
| 100              | ~108                 | "Noticeable but still usable."     |  
| 150              | ~160                 | "Laggy, immersion reduced."        |  
| 200              | ~220                 | "Unusable, frame stuttering."      |  

✅ **Observed**: Latency above 150ms caused significant usability issues.  
❌ **Issues**: Higher latency led to dropped frames and delayed input response.  

---

### Haptic Controls Map Movement  
#### Test Purpose  
To test whether haptic controls allow users to navigate the virtual map.  

#### Necessities  
[Haptic](#Haptic), Compatible Unity test world  

#### Steps  
1. Start the Unity test environment and connect the Ultraleap haptic device.  
2. Use hand gestures to simulate forward, backward, left, and right map movements.  
3. Observe the responsiveness and accuracy of the movements.  

#### Results  
✅ **Observed**: Haptic gestures successfully controlled map movements with minimal delay.  
❌ **Issues**: Gestures were less responsive under high latency conditions simulated at 150ms+.  

---

### Client Communication via Microphone  
#### Test Purpose  
To verify that users can communicate with each other using microphone inputs in the VR environment.  

#### Necessities  
[VR](#VR)  

#### Steps  
1. Start the multiplayer test world with two VR headsets.  
2. Connect microphones for both users.  
3. Speak into one microphone and check if the audio is heard on the other headset.  

#### Results  
✅ **Observed**: Audio was transmitted successfully in real-time with minimal delay.  
❌ **Issues**: None observed during testing.  

---

### Haptic & VR User Experience  
#### Test Purpose  
To assess the combined effects of latency on VR and haptic device usability.  

#### Necessities  
[VR](#VR), [Haptic](#Haptic), [Network](#Network)  

#### Steps  
1. Start the VR environment with haptic feedback enabled.  
2. Introduce network latency using **Clumsy** at 50ms, 100ms, and 200ms.  
3. Users complete tasks involving both VR visuals and haptic feedback.  
4. Collect user feedback via a questionnaire.  

#### Results  
| **Latency (ms)** | **User Feedback (Usability)**       | **Performance Issues**                |  
|------------------|-------------------------------------|---------------------------------------|  
| 50               | "Smooth and responsive."           | None                                  |  
| 100              | "Slight delay, still acceptable."  | Minor input lag for haptic gestures.  |  
| 200              | "Unusable, delays are too severe." | Visual and haptic feedback disrupted. |  

✅ **Observed**: Latency above 100ms noticeably impacted the experience.  
❌ **Issues**: Combined latency caused loss of immersion at 200ms.  

---

## Conclusion  
The tests demonstrate that:  
1. **VR rendering** and **haptic feedback** perform well under low latency (<100ms).  
2. Higher latencies (>150ms) degrade usability, performance, and user experience.  
3. Haptic gestures and real-time communication function effectively under ideal conditions but struggle with significant latency.  

Future work will focus on optimizing latency mitigation strategies and refining the user experience under varying network conditions.  
