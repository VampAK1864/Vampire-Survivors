using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public Rigidbody2D theRB; // The rigidbody component.
    public float moveSpeed; // The speed at which the enemy moves.
    private Transform target; // The target that the enemy will follow.

    void Start()
    {
        target = FindObjectOfType<PlayerController>().transform; // Find the player and set it as the target.
    }

    void Update()
    {
        theRB.velocity = (target.position - transform.position).normalized * moveSpeed; // Move the enemy towards the target.
    }
}
