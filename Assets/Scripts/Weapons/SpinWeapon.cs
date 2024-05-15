using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using Unity.Mathematics;
using UnityEngine;

public class SpinWeapon : Weapon // Inherits from the Weapon class. GK
{
    public float rotateSpeed; // The speed at which the weapon rotates. AK
    public Transform holder, fireballToSpawn; // The holder of the weapon and the fireball to spawn. AK
    public float timeBetweenSpawn; // The time between spawning fireballs. AK
    private float spawnCounter; // The counter for the spawn time. AK
    public EnemyDamager damager; // The enemy damager. GK

    void Start()
    {
        SetStats(); // Set the stats. GK
        UIController.instance.levelUpButtons[0].UpdateButtonDisplay(this); // Update the button display. GK
        
    }

    void Update()
    {
       // holder.rotation = Quaternion.Euler(0f, 0f, holder.rotation.eulerAngles.z + (rotateSpeed * Time.deltaTime)); // Rotate the weapon around the z-axis. AK
       holder.rotation = Quaternion.Euler(0f, 0f, holder.rotation.eulerAngles.z + (rotateSpeed * Time.deltaTime * stats[weaponLevel].speed)); // Rotate the weapon around the z-axis. GK
        spawnCounter -= Time.deltaTime; // Decrease the spawn counter. AK
        if(spawnCounter <= 0) // If the spawn counter is less than or equal to 0. AK
        {
            spawnCounter = timeBetweenSpawn; // Reset the spawn counter. AK

            //Instantiate(fireballToSpawn, fireballToSpawn.position, fireballToSpawn.rotation, holder).gameObject.SetActive(true); // Spawn the fireball at the fireball's position and rotation as a child of the holder. AK

            for (int i = 0; i < stats[weaponLevel].amount; i++) // For each fireball. GK
            {
                float rot = (360f / stats[weaponLevel].amount) * i; // Calculate the rotation. GK
                Instantiate(fireballToSpawn, fireballToSpawn.position, Quaternion.Euler(0f, 0f, rot), holder).gameObject
                    .SetActive(true); // Instantiate the fireball at the position and rotation. GK
                SFXManager.instance.PlaySFX(8); // Play the sound effect. GK
            }
        }
        if(statsUpdated) // If the stats are updated. GK
        {
            SetStats(); // Set the stats. GK
            statsUpdated = false; // Set the stats updated to false. GK
        }
    }
    public void SetStats() // Function to set the stats of the weapon. GK
    {
        damager.damageAmount = stats[weaponLevel].damage; // Set the damage amount of the damager to the damage of the weapon. GK       
        transform.localScale= Vector3.one * stats[weaponLevel].range; // Set the scale of the weapon to the range of the weapon. GK
        timeBetweenSpawn = stats[weaponLevel].timeBetweenAttacks; // Set the time between spawn to the time between attacks of the weapon. GK
        damager.lifeTime = stats[weaponLevel].duration; // Set the life time of the damager to the duration of the weapon. GK
        spawnCounter=0f; // Reset the spawn counter. GK
    }
}