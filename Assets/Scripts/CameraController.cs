using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Transform target; // The target that the camera will follow. AK

    void Start()
    {
        target = FindObjectOfType<PlayerController>().transform; // Find the player and set it as the target. AK
    }

    void LateUpdate() // LateUpdate is called after all Update functions have been called. AK
    {
        transform.position = new Vector3(target.position.x, target.position.y, transform.position.z); // Set the camera's position to the target's position. AK
    }
}