using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamager : MonoBehaviour
{
    public float damageAmount; // The amount of damage the enemy deals.
    public float lifeTime, growSpeed = 5f; // The lifetime of the enemy and the speed at which the enemy grows.
    private Vector3 targetSize; // The target size of the enemy.
    public bool shouldKnockBack; // Should the enemy knock back the player.
    public bool destroyParent; // Should the parent be destroyed.
    void Start()
    {
        //Destroy(gameObject, lifeTime); // Destroy the enemy after the lifetime.

        targetSize = transform.localScale; // Set the target size to the current scale.
        transform.localScale = Vector3.zero; // Set the scale to zero.
    }

    void Update()
    {
        transform.localScale = Vector3.MoveTowards(transform.localScale, targetSize, growSpeed * Time.deltaTime); // Grow the enemy towards the target size.

        lifeTime -= Time.deltaTime; // Decrease the lifetime.

        if(lifeTime <= 0) // If the lifetime is less than or equal to 0.
        {
            targetSize = Vector3.zero; // Set the target size to zero.

            if(transform.localScale.x == 0f) // If the scale is zero.
            {
                Destroy(gameObject); // Destroy the enemy.

                if(destroyParent) // If the parent should be destroyed.
                {
                    Destroy(transform.parent.gameObject); // Destroy the parent.
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) // When the enemy collides with something.
    {
        if(collision.tag == "Enemy") // If the enemy collides with the player.
        {
            collision.GetComponent<EnemyController>().TakeDamage(damageAmount, shouldKnockBack); // Take damage.
        }
    }
}