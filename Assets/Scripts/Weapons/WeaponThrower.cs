using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponThrower : Weapon
{
    public EnemyDamager damager; // The enemy damager. GK
    private float throwCounter; // The counter for the throw. GK
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(statsUpdated == true) // If the stats are updated. GK
        {
            statsUpdated = false; // Set the stats updated to false. GK
            SetStats(); // Set the stats. GK
        }
        throwCounter -= Time.deltaTime; // Decrease the throw counter. GK
        if (throwCounter <= 0)
        {
            throwCounter = stats[weaponLevel].timeBetweenAttacks; // Reset the throw counter. GK
            for (int i = 0; i < stats[weaponLevel].amount; i++)
            {
                Instantiate(damager, damager.transform.position, damager.transform.rotation).gameObject.SetActive(true); // Instantiate the damager at the position and rotation. GK

            }
        }
    }
    void SetStats() // Function to set the stats of the weapon. GK
    {
        damager.damageAmount = stats[weaponLevel].damage; // Set the damage amount of the damager to the damage of the weapon. GK
        damager.lifeTime = stats[weaponLevel].duration; // Set the life time of the damager to the duration of the weapon. GK
        damager.transform.localScale = Vector3.one * stats[weaponLevel].range; // Set the scale of the damager to the range of the weapon. GK
        throwCounter = 0f; // Reset the throw counter. GK
    }
}
