using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DamageNumber : MonoBehaviour
{
    public TMP_Text damageText; // The text component of the damage number. AK
    public float lifeTime; // The lifetime of the damage number. AK
    private float lifeCounter; // The counter for the lifetime. AK
    public float floatSpeed = 1f; // The speed at which the damage number floats. AK

    void Update()
    {
        if(lifeCounter > 0) // If the life counter is greater than 0. AK
        {
            lifeCounter -= Time.deltaTime; // Decrease the life counter. AK
            if(lifeCounter <= 0) // If the life counter is less than or equal to 0. AK
            {
                    //Destroy(gameObject); // Destroy the damage number. AK

                    DamageNumberController.instance.PlaceInPool(this); // Place the damage number in the pool. AK
            }
        }

        // if(Input.GetKeyDown(KeyCode.U)) // If the U key is pressed. AK
        // {
        //     Setup(45); // Setup the damage number. AK
        // }

        transform.position += Vector3.up * floatSpeed * Time.deltaTime; // Move the damage number up. AK
    }

    public void Setup(int damageDisplay) // Function to setup the damage number. AK
    {
        lifeCounter = lifeTime; // Set the life counter to the lifetime. AK

        damageText.text = damageDisplay.ToString(); // Set the text of the damage number to the damage display. AK
    }
}