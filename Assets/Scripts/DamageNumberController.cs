using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageNumberController : MonoBehaviour
{
    public static DamageNumberController instance; // The instance of the damage number controller.

    private void Awake() // When the script is loaded.
    {
        instance = this; // Set the instance to this.
    }

    public DamageNumber numberToSpawn; // The damage number to spawn.
    public Transform numberCanvas; // The canvas to spawn the damage number on.

    private List<DamageNumber> numberPool = new List<DamageNumber>(); // The pool of damage numbers.

    void Start()
    {

    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.U)) // If the U key is pressed.
        {
            SpawnDamage(57f, new Vector3(4, 3, 0)); // Spawn damage.
        }
    }

    public void SpawnDamage(float damageAmount, Vector3 location) // Function to spawn damage.
    {
        int rounded = Mathf.RoundToInt(damageAmount); // Round the damage amount.

        //DamageNumber newDamage = Instantiate(numberToSpawn, location, Quaternion.identity, numberCanvas); // Instantiate the damage number.

        DamageNumber newDamage = GetFromPool(); //  Get the damage number from the pool.

        newDamage.Setup(rounded); // Setup the damage number.
        newDamage.gameObject.SetActive(true); // Set the damage number to active.

        newDamage.transform.position = location; // Set the position of the damage number.
    }

    public DamageNumber GetFromPool() // Function to get a damage number from the pool.
    {
        DamageNumber numberToOutput = null; // The damage number to output.

        if(numberPool.Count == 0) // If the pool is empty.
        {
            numberToOutput = Instantiate(numberToSpawn, numberCanvas); // Instantiate a new damage number.
        }
        else
        {
            numberToOutput = numberPool[0]; // Set the damage number to the first number in the pool.
            numberPool.RemoveAt(0); // Remove the first number from the pool.
        }

        return numberToOutput; // Return the damage number.
    }

    public void PlaceInPool(DamageNumber numberToPlace) // Function to place a damage number in the pool.
    {
        numberToPlace.gameObject.SetActive(false); // Set the damage number to inactive.
        numberPool.Add(numberToPlace); // Add the damage number to the pool.
    }
}