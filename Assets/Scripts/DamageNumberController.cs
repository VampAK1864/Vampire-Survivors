using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageNumberController : MonoBehaviour
{
    public static DamageNumberController instance; // The instance of the damage number controller. AK

    private void Awake() // When the script is loaded. AK
    {
        instance = this; // Set the instance to this. AK
    }

    public DamageNumber numberToSpawn; // The damage number to spawn. AK
    public Transform numberCanvas; // The canvas to spawn the damage number on. AK

    private List<DamageNumber> numberPool = new List<DamageNumber>(); // The pool of damage numbers. AK

    void Start()
    {

    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.U)) // If the U key is pressed. AK
        {
            SpawnDamage(57f, new Vector3(4, 3, 0)); // Spawn damage. AK
        }
    }

    public void SpawnDamage(float damageAmount, Vector3 location) // Function to spawn damage. AK
    {
        int rounded = Mathf.RoundToInt(damageAmount); // Round the damage amount. AK

        //DamageNumber newDamage = Instantiate(numberToSpawn, location, Quaternion.identity, numberCanvas); // Instantiate the damage number. AK

        DamageNumber newDamage = GetFromPool(); //  Get the damage number from the pool. AK

        newDamage.Setup(rounded); // Setup the damage number. AK
        newDamage.gameObject.SetActive(true); // Set the damage number to active. AK

        newDamage.transform.position = location; // Set the position of the damage number. AK
    }

    public DamageNumber GetFromPool() // Function to get a damage number from the pool. AK
    {
        DamageNumber numberToOutput = null; // The damage number to output. AK

        if(numberPool.Count == 0) // If the pool is empty. AK
        {
            numberToOutput = Instantiate(numberToSpawn, numberCanvas); // Instantiate a new damage number. AK
        }
        else // If the pool is not empty. AK
        {
            numberToOutput = numberPool[0]; // Set the damage number to the first number in the pool. AK
            numberPool.RemoveAt(0); // Remove the first number from the pool. AK
        }

        return numberToOutput; // Return the damage number. AK
    }

    public void PlaceInPool(DamageNumber numberToPlace) // Function to place a damage number in the pool. AK
    {
        numberToPlace.gameObject.SetActive(false); // Set the damage number to inactive. AK
        numberPool.Add(numberToPlace); // Add the damage number to the pool. AK
    }
}