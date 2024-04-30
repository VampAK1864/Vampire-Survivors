using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance; // Create a singleton instance of the PlayerController. GK
    public void Awake()
    {
        instance = this; // Set the instance to this object. GK
    }
    public float moveSpeed; // The speed at which the player moves. AK

    public Animator anim; // The animator component. AK
    public float pickupRange = 1.5f; // The range of the attack. AK
    public Weapon activeWeapon; // The active weapon. GK

    void Start()
    {

    }

    void Update()
    {
        Vector3 moveInput = new Vector3(0f, 0f, 0f); // Create a new vector to store the input. AK
        moveInput.x = Input.GetAxisRaw("Horizontal"); // Get the horizontal input. AK
        moveInput.y = Input.GetAxisRaw("Vertical"); // Get the vertical input. AK

        //Debug.Log(moveInput); AK

        moveInput.Normalize(); // Normalize the vector so that the player moves at the same speed in all directions. AK

        transform.position += moveInput * moveSpeed * Time.deltaTime; // Move the player in the direction of the input. AK

        if(moveInput != Vector3.zero) // If the player is moving AK
        {
            anim.SetBool("isMoving", true); // Set the isMoving parameter in the animator to true. AK
        }
        else // If the player is not moving AK
        {
            anim.SetBool("isMoving", false); // Set the isMoving parameter in the animator to false. AK
        }
    }
}