using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthController : MonoBehaviour
{
    public static PlayerHealthController instance; // Create a singleton of the PlayerHealthController.

    private void Awake()
    {
        instance = this; // Set the instance to this script.
    }

    public float currentHealth, maxHealth; // Current and max health of the player.

    public Slider healthSlider; // The health slider.

    void Start()
    {
        currentHealth = maxHealth; // Set the current health to the max health at the start of the game.

        healthSlider.maxValue = maxHealth; // Set the max value of the health slider to the max health.
        healthSlider.value = currentHealth; // Set the value of the health slider to the current health.
    }

    void Update()
    {
        // if(Input.GetKeyDown(KeyCode.Space)) // If the space key is pressed.
        // {
        //     TakeDamage(10f); // Take 10 damage.
        // }
    }

    public void TakeDamage(float damageToTake) // Function to take damage.
    {
        currentHealth -= damageToTake;

        if(currentHealth <= 0) // If the current health is less than or equal to 0.
        {
            gameObject.SetActive(false); // Deactivate the player.
        }

        healthSlider.value = currentHealth; // Set the value of the health slider to the current health.
    }
}