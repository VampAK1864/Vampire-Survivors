using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class CloseAttackWeapon : Weapon
{
    public EnemyDamager damager; // The enemy damager. GK
    private float attackCounter, direction; // The counter for the attack and the direction. GK
    
    // Start is called before the first frame update
    void Start()
    {
        SetStats();// Set the stats. GK
    }

    // Update is called once per frame
    void Update()
    {
        if (statsUpdated == true) // If the stats are updated. GK
        {
            statsUpdated = false; // Set the stats updated to false. GK
            SetStats(); // Set the stats. GK
        }
        attackCounter -= Time.deltaTime; // Decrease the attack counter. GK
        if (attackCounter <= 0) // If the attack counter is less than or equal to 0. GK
        {
            attackCounter = stats[weaponLevel].timeBetweenAttacks; // Reset the attack counter. GK
            direction =  Input.GetAxisRaw("Horizontal"); // Get the direction. GK
            if(direction != 0) // If the horizontal axis is not 0. GK
            {
                if (direction > 0) // If the horizontal axis is greater than 0. GK
                {
                    damager.transform.rotation = Quaternion.identity; // Set the rotation of the damager. GK
                }
                else // If the horizontal axis is less than 0. GK
                {
                    damager.transform.rotation = Quaternion.Euler(0f, 0f, 180f); // Set the rotation of the damager. GK
                }
            }
            Instantiate(damager, damager.transform.position, damager.transform.rotation,transform).gameObject.SetActive(true); // Instantiate the damager at the position and rotation. GK
            for (int i=1; i< stats[weaponLevel].amount; i++) // For each attack. GK
            {
                float rot = (360f / stats[weaponLevel].amount) * i; // Calculate the rotation. GK
                Instantiate(damager, damager.transform.position, Quaternion.Euler(0f,0f,damager.transform.rotation.eulerAngles.z+rot), transform).gameObject.SetActive(true); // Instantiate the damager at the position and rotation. GK
            }
        }
    }
    void SetStats() // Function to set the stats of the weapon. GK
    {
        damager.damageAmount = stats[weaponLevel].damage; // Set the damage amount of the damager to the damage of the weapon. GK
        damager.lifeTime = stats[weaponLevel].duration; // Set the life time of the damager to the duration of the weapon. GK
        damager.transform.localScale = Vector3.one * stats[weaponLevel].range; // Set the scale of the damager to the range of the weapon. GK
        attackCounter = 0f; // Reset the attack counter. GK
        
    }
}
