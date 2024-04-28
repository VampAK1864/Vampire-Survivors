using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinWeapon : MonoBehaviour
{
    public float rotateSpeed; // The speed at which the weapon rotates. AK
    public Transform holder, fireballToSpawn; // The holder of the weapon and the fireball to spawn. AK
    public float timeBetweenSpawn; // The time between spawning fireballs. AK
    private float spawnCounter; // The counter for the spawn time. AK

    void Start()
    {

    }

    void Update()
    {
        holder.rotation = Quaternion.Euler(0f, 0f, holder.rotation.eulerAngles.z + (rotateSpeed * Time.deltaTime)); // Rotate the weapon around the z-axis. AK

        spawnCounter -= Time.deltaTime; // Decrease the spawn counter. AK
        if(spawnCounter <= 0) // If the spawn counter is less than or equal to 0. AK
        {
            spawnCounter = timeBetweenSpawn; // Reset the spawn counter. AK

            Instantiate(fireballToSpawn, fireballToSpawn.position, fireballToSpawn.rotation, holder).gameObject.SetActive(true); // Spawn the fireball at the fireball's position and rotation as a child of the holder. AK
        }
    }
}