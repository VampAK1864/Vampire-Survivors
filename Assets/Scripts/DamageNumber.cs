using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DamageNumber : MonoBehaviour
{
    public TMP_Text damageText; // The text component of the damage number.
    public float lifeTime; // The lifetime of the damage number.
    private float lifeCounter; // The counter for the lifetime.
    public float floatSpeed = 1f; // The speed at which the damage number floats.

    void Update()
    {
        if(lifeCounter > 0) // If the life counter is greater than 0.
        {
            lifeCounter -= Time.deltaTime; // Decrease the life counter.
            if(lifeCounter <= 0) // If the life counter is less than or equal to 0.
            {
                    //Destroy(gameObject); // Destroy the damage number.

                    DamageNumberController.instance.PlaceInPool(this); // Place the damage number in the pool.
            }
        }

        // if(Input.GetKeyDown(KeyCode.U)) // If the U key is pressed.
        // {
        //     Setup(45); // Setup the damage number.
        // }

        transform.position += Vector3.up * floatSpeed * Time.deltaTime; // Move the damage number up.
    }

    public void Setup(int damageDisplay) // Function to setup the damage number.
    {
        lifeCounter = lifeTime; // Set the life counter to the lifetime.

        damageText.text = damageDisplay.ToString(); // Set the text of the damage number to the damage display.
    }
}