using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyToSpawn; // The enemy prefab. AK
    public float timeToSpawn; // The rate at which the enemies spawn. AK
    private float spawnCounter; // The counter for the spawn time. AK
    public Transform minSpawn, maxSpawn; // The minimum and maximum spawn positions. AK
    private Transform target; // The target that the enemy will follow. AK
    private float despawnDistance; // The distance at which the enemy will despawn. AK
    private List<GameObject> spawnedEnemies = new List<GameObject>(); // The list of spawned enemies. AK
    public int checkPerFrame; // The number of enemies to check per frame. AK
    private int enemyToCheck; // The enemy to check. AK
    public List<WaveInfo> waves; // The list of waves. AK
    private int currentWave; // The current wave. AK
    private float waveCounter; // The counter for the wave. AK

    void Start()
    {
        //spawnCounter = timeToSpawn; // Set the spawn counter to the spawn time. AK

        target = PlayerHealthController.instance.transform; // Find the player and set it as the target. AK

        despawnDistance = Vector3.Distance(transform.position, maxSpawn.position) + 4f; // Set the despawn distance to the distance between the spawner and the maximum spawn position plus 4. AK

        currentWave = -1; // Set the current wave to -1. AK
        GoToNextWave(); // Go to the next wave. AK
    }

    void Update()
    {
        // spawnCounter -= Time.deltaTime; // Decrease the spawn counter. AK
        // if(spawnCounter <= 0) // If the spawn counter is less than or equal to 0. AK
        // {
        //     spawnCounter = timeToSpawn; // Reset the spawn counter. AK

        //     //Instantiate(enemyToSpawn, transform.position, transform.rotation); // Spawn the enemy at the spawner's position and rotation. AK

        //     GameObject newEnemy = Instantiate(enemyToSpawn, SelectSpawnPoint(), transform.rotation); // Spawn the enemy at the selected spawn point and rotation. AK

        //     spawnedEnemies.Add(newEnemy); // Add the new enemy to the list of spawned enemies. AK
        // }

        if(PlayerHealthController.instance.gameObject.activeSelf) // If the player is active. AK
        {
            if(currentWave < waves.Count) // If the current wave is less than the number of waves. AK
            {
                waveCounter -= Time.deltaTime; // Decrease the wave counter. AK
                if(waveCounter <= 0) // If the wave counter is less than or equal to 0. AK
                {
                    GoToNextWave(); // Go to the next wave. AK
                }
                spawnCounter -= Time.deltaTime; // Decrease the spawn counter. AK
                if(spawnCounter <= 0) // If the spawn counter is less than or equal to 0. AK
                {
                    spawnCounter = waves[currentWave].timeBetweenSpawns; // Reset the spawn counter. AK

                    GameObject newEnemy = Instantiate(waves[currentWave].enemyToSpawn, SelectSpawnPoint(), Quaternion.identity); // Spawn the enemy at the selected spawn point and Quaternion. AK

                    spawnedEnemies.Add(newEnemy); // Add the new enemy to the list of spawned enemies. AK
                }
            }
        }

        transform.position = target.position; // Move the spawner to the player's position. AK

        int checkTarget = enemyToCheck + checkPerFrame; // Set the check target to the enemy to check plus the check per frame. AK

        while(enemyToCheck < checkTarget) // While the enemy to check is less than the check target. AK
        {
            if(enemyToCheck < spawnedEnemies.Count) // If the enemy to check is less than the number of spawned enemies. AK
            {
                if(spawnedEnemies[enemyToCheck] != null) // If the enemy to check is not null. AK
                {
                    if(Vector3.Distance(transform.position, spawnedEnemies[enemyToCheck].transform.position) > despawnDistance) // If the distance between the spawner and the enemy is greater than the despawn distance. AK
                    {
                        Destroy(spawnedEnemies[enemyToCheck]); // Destroy the enemy. AK
                        spawnedEnemies.RemoveAt(enemyToCheck); // Remove the enemy from the list of spawned enemies. AK
                        checkTarget--; // Decrease the check target. AK
                    }
                    else // If the distance between the spawner and the enemy is less than or equal to the despawn distance. AK
                    {
                        enemyToCheck++; // Increase the enemy to check. AK
                    }
                }
                else // If the enemy to check is null. AK
                {
                    spawnedEnemies.RemoveAt(enemyToCheck); // Remove the enemy from the list of spawned enemies. AK
                    checkTarget--; // Decrease the check target. AK
                }
            }
            else // If the enemy to check is greater than or equal to the number of spawned enemies. AK
            {
                enemyToCheck = 0; // Set the enemy to check to 0. AK
                checkTarget = 0; // Set the check target to 0. AK
            }
        }
    }

    public Vector3 SelectSpawnPoint()
    {
        Vector3 spawnPoint = Vector3.zero; // The spawn point. AK

        bool spawnVerticalEdge = Random.Range(0f, 1f) > .5f; // Randomly select if the spawn point is on the vertical edge. AK

        if(spawnVerticalEdge) // If the spawn point is on the vertical edge. AK
        {
            spawnPoint.y = Random.Range(minSpawn.position.y, maxSpawn.position.y); // Set the y position to a random value between the minimum and maximum spawn positions. AK

            if(Random.Range(0f, 1f) > .5f) // If the random value is greater than .5. AK
            {
                spawnPoint.x = maxSpawn.position.x; // Set the x position to the maximum spawn position. AK
            }
            else // If the random value is less than or equal to .5. AK
            {
                spawnPoint.x = minSpawn.position.x; // Set the x position to the minimum spawn position. AK
            }
        }
        else
        {
            spawnPoint.x = Random.Range(minSpawn.position.x, maxSpawn.position.x); // Set the y position to a random value between the minimum and maximum spawn positions. AK

            if(Random.Range(0f, 1f) > .5f) // If the random value is greater than .5. AK
            {
                spawnPoint.y = maxSpawn.position.y; // Set the x position to the maximum spawn position. AK
            }
            else // If the random value is less than or equal to .5. AK
            {
                spawnPoint.y = minSpawn.position.y; // Set the x position to the minimum spawn position. AK
            }
        }
        return spawnPoint; // Return the spawn point. AK
    }

    public void GoToNextWave() // Go to the next wave. AK
    {
        currentWave++; // Increase the current wave. AK

        if(currentWave >= waves.Count) // If the current wave is less than the number of waves. AK
        {
            currentWave = waves.Count - 1; // Set the current wave to the last wave. AK
        }

        waveCounter = waves[currentWave].waveLength; // Set the wave counter to the wave length. AK
        spawnCounter = waves[currentWave].timeBetweenSpawns; // Set the spawn counter to the time between spawns. AK
    }
}

[System.Serializable] // Make the class serializable. AK
public class WaveInfo // The wave information. AK
{
    public GameObject enemyToSpawn; // The enemy to spawn. AK
    public float waveLength =10f; // The length of the wave. AK
    public float timeBetweenSpawns = 1f; // The time between spawns. AK
}