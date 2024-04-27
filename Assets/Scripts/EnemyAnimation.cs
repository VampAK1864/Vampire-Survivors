using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimation : MonoBehaviour
{
    public Transform sprite; // The sprite object.
    public float speed; // The speed at which the sprite rotates.
    public float minSize, maxSize; // The minimum and maximum size of the sprite.
    private float activeSize; // The size of the sprite.

    void Start()
    {
        activeSize = maxSize; // Set the active size to the maximum size.

        speed = speed * Random.Range(.75f, 1.25f); // Randomize the speed.
    }

    void Update()
    {
        sprite.localScale = Vector3.MoveTowards(sprite.localScale, Vector3.one * activeSize, speed * Time.deltaTime); // Change the size of the sprite.

        if(sprite.localScale.x == activeSize) // If the sprite has reached the active size.
        {
            if(activeSize == maxSize) // If the active size is the maximum size.
            {
                activeSize = minSize; // Set the active size to the minimum size.
            }
            else
            {
                activeSize = maxSize; // Set the active size to the maximum size.
            }
        }
    }
}
