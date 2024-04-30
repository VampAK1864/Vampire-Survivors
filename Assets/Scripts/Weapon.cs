using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public List<WeaponStats> stats; // The stats of the weapon. GK

    public int weaponLevel; // The level of the weapon. GK
    [HideInInspector]
    public bool statsUpdated; // If the stats are updated. GK
    public void LevelUp() // Function to level up the weapon. GK
    {
        if(weaponLevel < stats.Count - 1) // If the weapon level is less than the stats count. GK
        {
            weaponLevel++; // Increase the weapon level. GK
            statsUpdated= true; // Set the stats updated to true. GK
        }
    }
}
[System.Serializable]
public class WeaponStats // The stats of the weapon. GK 
{
    public float speed, damage, range, timeBetweenAttacks, amount, duration; // The speed, damage, range, time between attacks, amount, and duration of the weapon. GK    
}