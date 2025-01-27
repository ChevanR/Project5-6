using System.Drawing;
using HapE.Unity;
using UnityEngine;

public class FingerContactHandler : MonoBehaviour
{
    public int id;
    private CustomHapEDeviceManager hapEDeviceManager;
    [SerializeField] public string jsonFileName;
    private Vector3 handPos;
    // This method will be triggered during contact

    // Trigger event for detecting contact (when IsTrigger is true)
    private void OnTriggerEnter(Collider other)
    {
        // Trigger OnContact when touching any object
        hapEDeviceManager.Enable(id);
    }

    private void Update()
    {
        Vector3 point = transform.position;
        Vector2 relPos = new(point.x+handPos.x,point.z+handPos.z+0.05f);
        //Debug.Log("Here relPos: " + relPos + " from finger-hand: "+ point + " - "+ handPos);
        hapEDeviceManager.UpdateValue(id, relPos);
    }

    private void OnTriggerExit()
    {
        hapEDeviceManager.Disable(id);
    }


    private void Start()
    {
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
