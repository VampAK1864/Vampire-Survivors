using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ZoneWeapon : Weapon
{
    public EnemyDamager damager; // The enemy damager. GK
    private float spawnTime, spawnCounter; // The time between spawning and the counter for the spawn time. GK
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (statsUpdated == true) // If the stats are updated. GK
        {
            statsUpdated = false; // Set the stats updated to false. GK
            SetStats(); // Set the stats. GK
        }
        spawnCounter -= Time.deltaTime; // Decrease the spawn counter. GK
        // if (spawnCounter <= 0) // If the spawn counter is less than or equal to 0. GK
        // {
        //     spawnCounter = spawnTime; // Reset the spawn counter. GK
        //     Instantiate(damager, damager.transform.position, Quaternion.identity, transform).gameObject.SetActive(true); // Instantiate the damager at the position. GK
        // }
    }

    void SetStats() // Function to set the stats of the weapon. GK
    {
        damager.damageAmount = stats[weaponLevel].damage; // Set the damage amount of the damager to the damage of the weapon. GK
        damager.lifeTime = stats[weaponLevel].duration; // Set the life time of the damager to the duration of the weapon. GK
        damager.timeBetweenDamage = stats[weaponLevel].speed; // Set the time between damage to the speed of the weapon. GK
        damager.transform.localScale = Vector3.one * stats[weaponLevel].range; // Set the scale of the damager to the range of the weapon. GK\
        spawnTime = stats[weaponLevel].timeBetweenAttacks; // Set the spawn time to the time between attacks of the weapon. GK
    }
}
