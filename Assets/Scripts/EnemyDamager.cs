using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamager : MonoBehaviour
{
    public float damageAmount; // The amount of damage the enemy deals. AK
    public float lifeTime, growSpeed = 5f; // The lifetime of the enemy and the speed at which the enemy grows. AK
    private Vector3 targetSize; // The target size of the enemy. AK
    public bool shouldKnockBack; // Should the enemy knock back the player. AK
    public bool destroyParent; // Should the parent be destroyed. AK
    void Start()
    {
        //Destroy(gameObject, lifeTime); // Destroy the enemy after the lifetime. AK

        targetSize = transform.localScale; // Set the target size to the current scale. AK
        transform.localScale = Vector3.zero; // Set the scale to zero. AK
    }

    void Update()
    {
        transform.localScale = Vector3.MoveTowards(transform.localScale, targetSize, growSpeed * Time.deltaTime); // Grow the enemy towards the target size. AK

        lifeTime -= Time.deltaTime; // Decrease the lifetime. AK

        if(lifeTime <= 0) // If the lifetime is less than or equal to 0. AK
        {
            targetSize = Vector3.zero; // Set the target size to zero. AK

            if(transform.localScale.x == 0f) // If the scale is zero. AK
            {
                Destroy(gameObject); // Destroy the enemy. AK

                if(destroyParent) // If the parent should be destroyed. AK
                {
                    Destroy(transform.parent.gameObject); // Destroy the parent. AK
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) // When the enemy collides with something. AK
    {
        if(collision.tag == "Enemy") // If the enemy collides with the player. AK
        {
            collision.GetComponent<EnemyController>().TakeDamage(damageAmount, shouldKnockBack); // Take damage. AK
        }
    }
}