using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyToSpawn; // The enemy prefab.
    public float timeToSpawn; // The rate at which the enemies spawn.
    private float spawnCounter; // The counter for the spawn time.
    public Transform minSpawn, maxSpawn; // The minimum and maximum spawn positions.
    private Transform target; // The target that the enemy will follow.
    private float despawnDistance; // The distance at which the enemy will despawn.
    private List<GameObject> spawnedEnemies = new List<GameObject>(); // The list of spawned enemies.
    public int checkPerFrame; // The number of enemies to check per frame.
    private int enemyToCheck; // The enemy to check.

    void Start()
    {
        spawnCounter = timeToSpawn; // Set the spawn counter to the spawn time.

        target = PlayerHealthController.instance.transform; // Find the player and set it as the target.

        despawnDistance = Vector3.Distance(transform.position, maxSpawn.position) + 4f; // Set the despawn distance to the distance between the spawner and the maximum spawn position plus 4.
    }

    void Update()
    {
        spawnCounter -= Time.deltaTime; // Decrease the spawn counter.
        if(spawnCounter <= 0) // If the spawn counter is less than or equal to 0.
        {
            spawnCounter = timeToSpawn; // Reset the spawn counter.

            //Instantiate(enemyToSpawn, transform.position, transform.rotation); // Spawn the enemy at the spawner's position and rotation.

            GameObject newEnemy = Instantiate(enemyToSpawn, SelectSpawnPoint(), transform.rotation); // Spawn the enemy at the selected spawn point and rotation.

            spawnedEnemies.Add(newEnemy); // Add the new enemy to the list of spawned enemies.
        }

        transform.position = target.position; // Move the spawner to the player's position.

        int checkTarget = enemyToCheck + checkPerFrame; // Set the check target to the enemy to check plus the check per frame.

        while(enemyToCheck < checkTarget)
        {
            if(enemyToCheck < spawnedEnemies.Count)
            {
                if(spawnedEnemies[enemyToCheck] != null)
                {
                    if(Vector3.Distance(transform.position, spawnedEnemies[enemyToCheck].transform.position) > despawnDistance) // If the distance between the spawner and the enemy is greater than the despawn distance.
                    {
                        Destroy(spawnedEnemies[enemyToCheck]); // Destroy the enemy.
                        spawnedEnemies.RemoveAt(enemyToCheck); // Remove the enemy from the list of spawned enemies.
                        checkTarget--;
                    }
                    else
                    {
                        enemyToCheck++;
                    }
                }
                else
                {
                    spawnedEnemies.RemoveAt(enemyToCheck);
                    checkTarget--;
                }
            }
            else
            {
                enemyToCheck = 0;
                checkTarget = 0;
            }
        }
    }

    public Vector3 SelectSpawnPoint()
    {
        Vector3 spawnPoint = Vector3.zero; // The spawn point.

        bool spawnVerticalEdge = Random.Range(0f, 1f) > .5f; // Randomly select if the spawn point is on the vertical edge.

        if(spawnVerticalEdge)
        {
            spawnPoint.y = Random.Range(minSpawn.position.y, maxSpawn.position.y); // Set the y position to a random value between the minimum and maximum spawn positions.

            if(Random.Range(0f, 1f) > .5f)
            {
                spawnPoint.x = maxSpawn.position.x; // Set the x position to the maximum spawn position.
            }
            else
            {
                spawnPoint.x = minSpawn.position.x; // Set the x position to the minimum spawn position.
            }
        }
        else
        {
            spawnPoint.x = Random.Range(minSpawn.position.x, maxSpawn.position.x); // Set the y position to a random value between the minimum and maximum spawn positions.

            if(Random.Range(0f, 1f) > .5f)
            {
                spawnPoint.y = maxSpawn.position.y; // Set the x position to the maximum spawn position.
            }
            else
            {
                spawnPoint.y = minSpawn.position.y; // Set the x position to the minimum spawn position.
            }
        }
        return spawnPoint; // Return the spawn point.
    }
}