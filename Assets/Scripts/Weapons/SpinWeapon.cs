using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinWeapon : MonoBehaviour
{
    public float rotateSpeed; // The speed at which the weapon rotates.
    public Transform holder, fireballToSpawn; // The holder of the weapon and the fireball to spawn.
    public float timeBetweenSpawn; // The time between spawning fireballs.
    private float spawnCounter; // The counter for the spawn time.

    void Start()
    {

    }

    void Update()
    {
        holder.rotation = Quaternion.Euler(0f, 0f, holder.rotation.eulerAngles.z + (rotateSpeed * Time.deltaTime)); // Rotate the weapon around the z-axis.

        spawnCounter -= Time.deltaTime; // Decrease the spawn counter.
        if(spawnCounter <= 0) // If the spawn counter is less than or equal to 0.
        {
            spawnCounter = timeBetweenSpawn; // Reset the spawn counter.

            Instantiate(fireballToSpawn, fireballToSpawn.position, fireballToSpawn.rotation, holder).gameObject.SetActive(true); // Spawn the fireball at the fireball's position and rotation as a child of the holder.
        }
    }
}