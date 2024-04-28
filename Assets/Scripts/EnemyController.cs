using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public Rigidbody2D theRB; // The rigidbody component.
    public float moveSpeed; // The speed at which the enemy moves.
    private Transform target; // The target that the enemy will follow.
    public float damage; // The damage that the enemy deals.
    public float hitWaitTime = 1f; // The time to wait before the enemy can hit the player again.
    private float hitCounter; // The counter for the hit wait time.
    public float health =5f; // The health of the enemy.
    public float knockBackTime = .5f; // The time to knock back the enemy.
    private float knockBackCounter; // The counter for the knock back time.

    void Start()
    {
        //target = FindObjectOfType<PlayerController>().transform; // Find the player and set it as the target.
        target = PlayerHealthController.instance.transform; // Find the player and set it as the target.
    }

    void Update()
    {
        if(knockBackCounter > 0) // If the knock back counter is greater than 0.
        {
            knockBackCounter -= Time.deltaTime; // Decrease the knock back counter.

            if(moveSpeed > 0) // If the move speed is greater than 0.
            {
                moveSpeed = -moveSpeed * 2f; // Set the move speed to the negative move speed times 2.
            }

            if(knockBackCounter <= 0) // If the knock back counter is less than or equal to 0.
            {
                moveSpeed = Mathf.Abs(moveSpeed * .5f); // Set the move speed to the negative move speed times 0.5.
            }
        }

        theRB.velocity = (target.position - transform.position).normalized * moveSpeed; // Move the enemy towards the target.

        if(hitCounter > 0) // If the hit counter is greater than 0.
        {
            hitCounter -= Time.deltaTime; // Decrease the hit counter.
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) // When the enemy collides with something.
    {
        if(collision.gameObject.tag == "Player" && hitCounter <= 0f) // If the enemy collides with the player.
        {
            PlayerHealthController.instance.TakeDamage(damage); // Take 10 damage.

            hitCounter = hitWaitTime; // Set the hit counter to the hit wait time.
        }
    }

    public void TakeDamage(float damageToTake) // Function to take damage.
    {
        health -= damageToTake; // Decrease the health by the damage.

        if(health <= 0) // If the health is less than or equal to 0.
        {
            Destroy(gameObject); // Destroy the enemy.
        }
    }

    public void TakeDamage(float damageToTake, bool shouldKnockBack)
    {
        TakeDamage(damageToTake); // Take damage.

        if(shouldKnockBack == true) // If the enemy should be knocked back.
        {
            knockBackCounter = knockBackTime; // Set the knock back counter to the knock back time.
        }
    }
}
