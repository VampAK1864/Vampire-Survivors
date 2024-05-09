using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPickup : MonoBehaviour
{
    public int coinAmount = 1; // The value of the coin. D
    private bool movingToPlayer; // Whether the experience should move to the player. GK

    public float moveSpeed; // The speed at which the experience moves. GK  
    public float timeBetweenChecks; // The time between checks for the player. GK

    private float checkCounter; // The counter for the checks. GK

    private PlayerController player; // The variable to keep track of the player. GK

    // Start is called before the first frame update
    void Start()
    {
        player = PlayerController.instance;
    }

    // Update is called once per frame
    void Update()
    {
        if (movingToPlayer) // If the experience is moving to the player. GK
        {
            transform.position = Vector3.MoveTowards(transform.position,
                PlayerHealthController.instance.transform.position,
                moveSpeed * Time.deltaTime); // Move the experience towards the player. GK
        }
        else
        {
            checkCounter -= Time.deltaTime; // Decrement the check counter. GK
            if (checkCounter <= 0f) // If the check counter is less than or equal to 0. GK
            {
                checkCounter = timeBetweenChecks; // Reset the check counter. GK
                if (Vector3.Distance(transform.position, player.transform.position) <
                    player.pickupRange) // If the distance between the experience and the player is less than the pickup range. GK
                {
                    movingToPlayer = true; // Set movingToPlayer to true. GK
                    moveSpeed += player.moveSpeed; // Add the player's move speed to the experience's move speed. GK
                }
            }
        }
    }

    public void OnTriggerEnter2D(Collider2D collision) // When the experience collides with the player. GK
    {
        if (collision.tag == "Player") // If the player collides with the experience. GK
        {
            CoinController.instance.AddCoins(coinAmount);
            Destroy(gameObject); // Destroy the experience. GK
        }
    }
}