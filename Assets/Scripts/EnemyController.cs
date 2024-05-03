using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public Rigidbody2D theRB; // The rigidbody component. AK
    public float moveSpeed; // The speed at which the enemy moves. AK
    private Transform target; // The target that the enemy will follow. AK
    public float damage; // The damage that the enemy deals. AK
    public float hitWaitTime = 1f; // The time to wait before the enemy can hit the player again. AK
    private float hitCounter; // The counter for the hit wait time. AK
    public float health =5f; // The health of the enemy. AK
    public float knockBackTime = .5f; // The time to knock back the enemy. AK
    private float knockBackCounter; // The counter for the knock back time. AK
    public int expToGive = 1; // The experience to give when the enemy is destroyed. GK

    void Start()
    {
        //target = FindObjectOfType<PlayerController>().transform; // Find the player and set it as the target. AK
        target = PlayerHealthController.instance.transform; // Find the player and set it as the target. AK
    }

    void Update()
    {
        if(PlayerController.instance.gameObject.activeSelf == true) // If the player is not active. GK
        {
            if(knockBackCounter > 0) // If the knock back counter is greater than 0. AK
            {
                knockBackCounter -= Time.deltaTime; // Decrease the knock back counter. AK

                if(moveSpeed > 0) // If the move speed is greater than 0. AK
                {
                    moveSpeed = -moveSpeed * 2f; // Set the move speed to the negative move speed times 2. AK
                }

                if(knockBackCounter <= 0) // If the knock back counter is less than or equal to 0. AK
                {
                    moveSpeed = Mathf.Abs(moveSpeed * .5f); // Set the move speed to the negative move speed times 0.5. AK
                }
            }

            theRB.velocity = (target.position - transform.position).normalized * moveSpeed; // Move the enemy towards the target. AK

            if(hitCounter > 0) // If the hit counter is greater than 0. AK
            {
                hitCounter -= Time.deltaTime; // Decrease the hit counter. AK
            }
        }
        else
        {
            theRB.velocity = Vector2.zero; // Set the velocity to 0. GK
        }
        
    }

    private void OnCollisionEnter2D(Collision2D collision) // When the enemy collides with something. AK
    {
        if(collision.gameObject.tag == "Player" && hitCounter <= 0f) // If the enemy collides with the player. AK
        {
            PlayerHealthController.instance.TakeDamage(damage); // Take 10 damage. AK

            hitCounter = hitWaitTime; // Set the hit counter to the hit wait time. AK
        }
    }

    public void TakeDamage(float damageToTake) // Function to take damage. AK
    {
        health -= damageToTake; // Decrease the health by the damage. AK

        if(health <= 0) // If the health is less than or equal to 0. AK
        {
            Destroy(gameObject); // Destroy the enemy. AK
            ExperienceLevelController.instance.SpawnExp(transform.position,expToGive); // Set the experience when the enemy is destroyed. GK 
        }

        DamageNumberController.instance.SpawnDamage(damageToTake, transform.position); // Spawn the damage number. AK
    }

    public void TakeDamage(float damageToTake, bool shouldKnockBack) // Function to take damage. AK
    {
        TakeDamage(damageToTake); // Take damage. AK

        if(shouldKnockBack == true) // If the enemy should be knocked back. AK
        {
            knockBackCounter = knockBackTime; // Set the knock back counter to the knock back time. AK
        }
    }
}