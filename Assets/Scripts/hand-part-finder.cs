using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class hand_part_finder : MonoBehaviour
{
    private Transform palm;
    private List<Transform> fingers = new List<Transform>();
    [SerializeField] string hand;

    // Start is called before the first frame update
    void Start()
    {
        // Start the coroutine to wait for all children to load
        StartCoroutine(FindHandParts());
    }

    // Coroutine to wait until all children are loaded
    IEnumerator FindHandParts()
    {
        Transform parent = transform;

        if (parent == null)
        {
            Debug.LogError("This GameObject does not have a parent. Please attach it to the hand object.");
            yield break; // Stop execution
        }

        // Wait for "Left Interaction Hand Contact Bones" to be created
        Transform handContactBones = null;
        while (handContactBones == null)
        {
            foreach (Transform child in parent)
            {
                if (child.name == hand + " Interaction Hand Contact Bones")
                {
                    handContactBones = child;
                    break;
                }
            }
            yield return null; // Wait for the next frame
        }

        //Debug.Log(handContactBones);

        // Identify palm and finger bones
        bool palmFound = false;
        int fingerCount = 0;

        while (!palmFound || fingerCount < 9)
        {
            palmFound = false;
            fingerCount = 0;
            fingers.Clear();

            foreach (Transform child in handContactBones)
            {
                // Check if the child is the palm
                if (child.name.ToLower().Contains("palm"))
                {
                    palm = child;
                    FingerContactHandler handler = child.GetComponent<FingerContactHandler>();
                    if (handler == null)
                    {
                        handler = child.gameObject.AddComponent<FingerContactHandler>();
                    }
                    child.GetComponent<FingerContactHandler>().id = 69;
                    palmFound = true;
                }
                // Check if the child is a finger bone
                else if (child.name.ToLower().Contains("finger"))
                {
                    if (!fingers.Contains(child))
                    {
                        fingers.Add(child);

                        // Dynamically add the contact handler
                        FingerContactHandler handler = child.GetComponent<FingerContactHandler>();
                        if (handler == null)
                        {
                            handler = child.gameObject.AddComponent<FingerContactHandler>();
                        }
                        else
                        {
                            Debug.Log("It already has stuff");
                        }
                    }
                }
            }

            fingerCount = fingers.Count;

            // If we haven't found everything, wait for the next frame
            if (!palmFound || fingerCount < 5)
            {
                yield return null; // Wait for the next frame
            }
        }
        int id = 0;

        foreach (Transform finger in fingers)
        {
            finger.GetComponent<FingerContactHandler>().id = id++;
        }
    }

    // Debugging purposes: Display palm and fingers in the console
    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.Space)) // Press Space to log the parts
        //{
        //    if (palm != null)
        //    {
        //        Debug.Log("Palm: " + palm.name);
        //    }

        //    for (int i = 0; i < fingers.Count; i++)
        //    {
        //        Debug.Log($"Finger {i + 1}: " + fingers[i].name);
        //    }
        //}
    }
}
