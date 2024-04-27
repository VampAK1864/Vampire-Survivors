using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed; // The speed at which the player moves.

    public Animator anim; // The animator component.

    void Start()
    {

    }

    void Update()
    {
        Vector3 moveInput = new Vector3(0f, 0f, 0f); // Create a new vector to store the input.
        moveInput.x = Input.GetAxisRaw("Horizontal"); // Get the horizontal input.
        moveInput.y = Input.GetAxisRaw("Vertical"); // Get the vertical input.

        //Debug.Log(moveInput);

        moveInput.Normalize(); // Normalize the vector so that the player moves at the same speed in all directions.

        transform.position += moveInput * moveSpeed * Time.deltaTime; // Move the player in the direction of the input.

        if(moveInput != Vector3.zero) // If the player is moving
        {
            anim.SetBool("isMoving", true); // Set the isMoving parameter in the animator to true.
        }
        else // If the player is not moving
        {
            anim.SetBool("isMoving", false); // Set the isMoving parameter in the animator to false.
        }
    }
}
