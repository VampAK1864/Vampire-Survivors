using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerStatUpgradeDisplay : MonoBehaviour
{
    public TMP_Text valueText, costText; // The text for the value and cost. GK
    public GameObject upgradeButton; // The upgrade button. GK

    public void UpdateDisplay(int cost, float oldValue, float newValue)
    {
        
        valueText.text= "Value: " + oldValue.ToString("F1") + "-> " + newValue.ToString("F1"); // Set the value text to the old and new value. GK
        costText.text = "Cost: " + cost; // Set the cost text to the cost. GK
        if(cost <= CoinController.instance.currentCoins) // If the cost is less than or equal to the current coins. GK
        {
            upgradeButton.SetActive(true); // Set the upgrade button to active. GK
        }
        else
        {
            upgradeButton.SetActive(false); // Set the upgrade button to false. GK
        }
        
    }
    public void ShowMaxLevel() // Function to show the max level. GK
    {
        valueText.text = "Max Level"; // Set the value text to max level. GK
        costText.text = "Max level"; // Set the cost text to empty. GK
        upgradeButton.SetActive(false); // Set the upgrade button to false. GK
    }
}
