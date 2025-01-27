using System.Collections;
using System.Collections.Generic;
using Leap.Unity.Interaction;
using UnityEngine;

public class extract_contact_data : MonoBehaviour
{
    [SerializeField] private InteractionHand hand;
    private bool bonesInitialized = false;  // Flag to track if bones are initialized


    // Start is called before the first frame update
    void Start()
    {
        if (hand == null)
        {
            Debug.LogError("InteractionHand is not assigned!");
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Wait until the hand and bones are properly initialized
        if (hand != null && !bonesInitialized)
        {
            ContactBone[] bones = hand.contactBones;

            // Check if bones is not null and then process it
            if (bones != null && bones.Length > 0)
            {
                bonesInitialized = true; // Set the flag to true once bones are initialized

                foreach (ContactBone bone in bones)
                {
                    Debug.Log(bone);  // Output the bone's information
                }
            }
        }
    }
}
