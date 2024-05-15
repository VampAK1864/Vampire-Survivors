using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthController : MonoBehaviour
{
    public static PlayerHealthController instance; // Create a singleton of the PlayerHealthController. AK

    private void Awake()
    {
        instance = this; // Set the instance to this script. AK
    }

    public float currentHealth, maxHealth; // Current and max health of the player. AK

    public Slider healthSlider; // The health slider. AK
    public GameObject deathEffect; // The death effect. GK

    void Start()
    {
        maxHealth = PlayerStatController.instance.health[0].value; // Set the max health to the health value. GK
        currentHealth = maxHealth; // Set the current health to the max health at the start of the game. AK

        healthSlider.maxValue = maxHealth; // Set the max value of the health slider to the max health. AK
        healthSlider.value = currentHealth; // Set the value of the health slider to the current health.AK
    }

    void Update()
    {
        // if(Input.GetKeyDown(KeyCode.Space)) // If the space key is pressed. AK
        // {
        //     TakeDamage(10f); // Take 10 damage. AK
        // }
    }

    public void TakeDamage(float damageToTake) // Function to take damage. AK
    {
        currentHealth -= damageToTake; // Decrease the current health by the damage. AK

        if(currentHealth <= 0) // If the current health is less than or equal to 0. AK
        {
            gameObject.SetActive(false); // Deactivate the player. AK
            LevelManager.instance.EndLevel(); // End the level. GK
            Instantiate(deathEffect, transform.position, transform.rotation); // Instantiate the death effect. GK
            
            SFXManager.instance.PlaySFX(3); // Play the sound effect. GK
        }

        healthSlider.value = currentHealth; // Set the value of the health slider to the current health. AK
    }
}