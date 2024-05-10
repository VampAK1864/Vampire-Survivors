using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatController : MonoBehaviour
{
    public static PlayerStatController instance; // Singleton. GK
    public void Awake() // GK
    {
        instance = this; // GK
    }

    public List<PlayerStatValue> moveSpeed, health, pickupRange, maxWeapons; // The list of player stats. GK
    public int moveSpeedLevelCount, healthLevelCount, pickupRangeLevelCount;// The level count of player stats. GK
    public int moveSpeedLevel, healthLevel, pickupRangeLevel, maxWeaponsLevel; // The level of player stats. GK
    // Start is called before the first frame update
    void Start()
    {
        for(int i=moveSpeed.Count - 1; i< moveSpeedLevelCount; i++) // The loop for the move speed. GK
        {
            moveSpeed.Add(new PlayerStatValue(moveSpeed[i].cost + moveSpeed[1].cost,moveSpeed[i].value + moveSpeed[1].value - moveSpeed[0].value)); // the cost and value of the move speed. GK
        }
        for(int i=health.Count - 1; i< healthLevelCount; i++) // The loop for the move speed. GK
        {
            health.Add(new PlayerStatValue(health[i].cost + health[1].cost,health[i].value + health[1].value - health[0].value)); // the cost and value of the health. GK
        }
        for(int i=pickupRange.Count - 1; i< pickupRangeLevelCount; i++) // The loop for the move speed. GK
        {
            pickupRange.Add(new PlayerStatValue(pickupRange[i].cost + pickupRange[1].cost,pickupRange[i].value + pickupRange[1].value - pickupRange[0].value)); // the cost and value of the pickup range. GK
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(UIController.instance.levelUpPanel.activeSelf) // If the level up panel is active. GK
        {
            UpdateDisplay();
        }
    }

    public void UpdateDisplay()
    {
        if (moveSpeedLevel < moveSpeed.Count - 1) // If the move speed level is less than the count. GK
        {
            UIController.instance.moveSpeedUpgradeDisplay.UpdateDisplay(moveSpeed[moveSpeedLevel + 1].cost, moveSpeed[moveSpeedLevel].value, moveSpeed[moveSpeedLevel+1].value); // Update the display of the move speed. GK

        }
        else
        {
            UIController.instance.moveSpeedUpgradeDisplay.ShowMaxLevel(); // Show the max level. GK
        }
        if (healthLevel < health.Count - 1) // If the health level is less than the count. GK
        {
            UIController.instance.healthUpgradeDisplay.UpdateDisplay(health[healthLevel + 1].cost, health[healthLevel].value, health[healthLevel+1].value); // Update the display of the move speed. GK

        }
        else
        {
            UIController.instance.healthUpgradeDisplay.ShowMaxLevel(); // Show the max level. GK
        }
        if (pickupRangeLevel < pickupRange.Count - 1) // If the pickup range level is less than the count. GK
        {
            UIController.instance.pickupRangeUpgradeDisplay.UpdateDisplay(pickupRange[pickupRangeLevel + 1].cost, pickupRange[pickupRangeLevel].value, pickupRange[pickupRangeLevel+1].value); // Update the display of the move speed. GK

        }
        else
        {
            UIController.instance.pickupRangeUpgradeDisplay.ShowMaxLevel(); // Show the max level. GK
        }
        if (maxWeaponsLevel < maxWeapons.Count - 1) // If the max weapons level is less than the count. GK
        {
            UIController.instance.maxWeaponsUpgradeDisplay.UpdateDisplay(maxWeapons[maxWeaponsLevel + 1].cost, maxWeapons[maxWeaponsLevel].value, maxWeapons[maxWeaponsLevel+1].value); // Update the display of the move speed. GK

        }
        else
        {
            UIController.instance.maxWeaponsUpgradeDisplay.ShowMaxLevel(); // Show the max level. GK
        }
    }
    public void PurchaseMoveSpeed() // Function to purchase the move speed. GK
    {
       moveSpeedLevel++; // Increase the move speed level. GK
       CoinController.instance.SpendCoins(moveSpeed[moveSpeedLevel].cost); // Spend the coins. GK
       UpdateDisplay();
       PlayerController.instance.moveSpeed = moveSpeed[moveSpeedLevel].value; // Set the player move speed. GK
    }
    public void PurchaseHealth() // Function to purchase the health. GK
    {
        healthLevel++; // Increase the health level. GK
        CoinController.instance.SpendCoins(health[healthLevel].cost); // Spend the coins. GK
        UpdateDisplay();
        PlayerHealthController.instance.maxHealth = health[healthLevel].value; // Set the player health. GK
        PlayerHealthController.instance.currentHealth +=
            health[healthLevel].value - health[healthLevel - 1].value; // Set the player health. GK
    }
    public void PurchasePickupRange() // Function to purchase the pickup range. GK
    {
        pickupRangeLevel++; // Increase the pickup range level. GK
        CoinController.instance.SpendCoins(pickupRange[pickupRangeLevel].cost); // Spend the coins. GK
        UpdateDisplay();
        PlayerController.instance.pickupRange = pickupRange[pickupRangeLevel].value; // Set the player pickup range. GK
    }
    public void PurchaseMaxWeapons() // Function to purchase the max weapons. GK
    {
        maxWeaponsLevel++; // Increase the max weapons level. GK
        CoinController.instance.SpendCoins(maxWeapons[maxWeaponsLevel].cost); // Spend the coins. GK
        UpdateDisplay();
        PlayerController.instance.maxWeapons = Mathf.RoundToInt(maxWeapons[maxWeaponsLevel].value); // Set the player max weapons. GK
    }
}
[System.Serializable] // This attribute allows the class to be serialized. GK
public class PlayerStatValue // The class for player stats. GK
{
    public int cost; // The cost of the stat. GK
    public float value; // The value of the stat. GK
    public PlayerStatValue(int newCost, float newValue) // The constructor of the class. GK
    {
        cost = newCost; // The cost of the stat. GK
        value = newValue; // The value of the stat. GK
    }
}
