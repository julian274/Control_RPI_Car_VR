using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class FollowHeadset : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // Ensure we're tracking the head
        InputTracking.disablePositionalTracking = false;
    }

    // Update is called once per frame
    void Update()
    {
        // Get the head's position and rotation
        Vector3 headPosition = InputTracking.GetLocalPosition(XRNode.Head);
        Quaternion headRotation = InputTracking.GetLocalRotation(XRNode.Head);

        // Set the camera's position and rotation to match
        transform.localPosition = headPosition;
        transform.localRotation = headRotation;
    }
}
