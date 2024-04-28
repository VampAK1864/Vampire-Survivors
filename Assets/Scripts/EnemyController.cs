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

    void Start()
    {
        //target = FindObjectOfType<PlayerController>().transform; // Find the player and set it as the target.
        target = PlayerHealthController.instance.transform; // Find the player and set it as the target.
    }

    void Update()
    {
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
}
