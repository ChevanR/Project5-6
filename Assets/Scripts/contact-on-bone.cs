using System.Drawing;
using HapE.Unity;
using UnityEngine;

public class FingerContactHandler : MonoBehaviour
{
    public int id;
    private CustomHapEDeviceManager hapEDeviceManager;
    [SerializeField] public string jsonFileName;
    private Vector3 handPos;
    // Trigger event for detecting contact
    private void OnTriggerEnter(Collider other)
    {
        // Trigger OnContact when touching any object
        hapEDeviceManager.Enable(id);
    }

    // Update the position of the hand, based on the relative pos added with an offset to make it better
    private void Update()
    {
        Vector3 point = transform.position;
        Vector2 relPos = new(point.x+handPos.x,point.z+handPos.z+0.05f);
        //Debug.Log("Here relPos: " + relPos + " from finger-hand: "+ point + " - "+ handPos);
        hapEDeviceManager.UpdateValue(id, relPos);
    }

    // Trigger event for detecting losing contact
    private void OnTriggerExit()
    {
        hapEDeviceManager.Disable(id);
    }


    private void Start()
    {
        // Try to find the hapEDeviceManager that manages this contact bone
        if (hapEDeviceManager == null)
        {
            // Safely navigate through the parent hierarchy
            Transform parentTransform = transform.parent;
            
            if (parentTransform != null)
            {
                //Debug.Log(parentTransform.name + " " + parentTransform.localPosition);
                handPos = parentTransform.localPosition;
                parentTransform = parentTransform.parent;
                if (parentTransform != null)
                {
                    hapEDeviceManager = parentTransform.parent.parent.GetComponent<CustomHapEDeviceManager>(); // The grandparent
                    //Debug.Log(hapEDeviceManager.name);
                }
            }
        }
    }
}
