using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileWeapon : Weapon
{
    public EnemyDamager damager; // The enemy damager. GK

    public Projectile projectile; // The projectile. GK
    private float shotCounter; // The counter for the shot. GK
    public float weaponRange; // The range of the weapon. GK
    public LayerMask whatIsEnemy; // The layer mask for the enemy. GK
    // Start is called before the first frame update
    void Start()
    {
        SetStats(); // Set the stats. GK
    }

    // Update is called once per frame
    void Update()
    {
        if (statsUpdated == true) // If the stats are updated. GK
        {
            statsUpdated = false; // Set the stats updated to false. GK
            SetStats(); // Set the stats. GK
        }
        shotCounter -= Time.deltaTime; // Decrease the shot counter. GK
        if (shotCounter <= 0) // If the shot counter is less than or equal to 0. GK
        {
            shotCounter = stats[weaponLevel].timeBetweenAttacks; // Reset the shot counter. GK
            Collider2D[] enemies = Physics2D.OverlapCircleAll(transform.position, weaponRange * stats[weaponLevel].range, whatIsEnemy); // Get all the enemies in the range. GK
            if(enemies.Length > 0) // If there are enemies in the range. GK
            {
                for (int i = 0; i < stats[weaponLevel].amount; i++) // For each enemy in the range. GK
                {
                   Vector3 targetPosition = enemies[Random.Range(0, enemies.Length)].transform.position; // Get the target position. GK
                   Vector3 direction = targetPosition - transform.position; // Get the direction. GK
                   float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg; // Get the angle. GK
                   angle -= 90; // Subtract 90 from the angle. GK
                   projectile.transform.rotation = Quaternion.AngleAxis(angle,Vector3.forward); // Set the rotation of the projectile. GK
                   Instantiate(projectile, projectile.transform.position, projectile.transform.rotation).gameObject.SetActive(true); // Instantiate the projectile at the position and rotation. GK
                }
            }
         }
    }
    void SetStats() // Function to set the stats of the weapon. GK
    {
        damager.damageAmount = stats[weaponLevel].damage; // Set the damage amount of the damager to the damage of the weapon. GK
        damager.lifeTime = stats[weaponLevel].duration; // Set the life time of the damager to the duration of the weapon. GK
        damager.transform.localScale = Vector3.one * stats[weaponLevel].range; // Set the scale of the damager to the range of the weapon. GK
        shotCounter = 0f; // Reset the shot counter. GK
        projectile.moveSpeed = stats[weaponLevel].speed; // Set the move speed of the projectile to the speed of the weapon. GK
    }
}
