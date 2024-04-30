using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine.UI;
using UnityEngine;

public class LevelUpSellectionButton : MonoBehaviour
{
    public TMP_Text upgradeDescText, nameLevelText; // The upgrade description text and the name level text. GK 

    public Image weaponIcon; // The weapon icon. GK
    private Weapon assignedWeapon; // The assigned weapon. GK   
    public void UpdateButtonDisplay(Weapon theWeapon) // Function to update the button display. GK
    {
        weaponIcon.sprite = theWeapon.icon; // Set the weapon icon to the weapon icon. GK
        nameLevelText.text = theWeapon.name + " - Lvl " + theWeapon.weaponLevel; // Set the name level text to the weapon name and level. GK
        upgradeDescText.text = theWeapon.stats[theWeapon.weaponLevel].upgradeText; // Set the upgrade description text to the weapon upgrade text. GK
        assignedWeapon = theWeapon; // Set the assigned weapon to the weapon. GK
    }
    public void SelectUpgrade() // Function to select the upgrade. GK
    {
        if(assignedWeapon != null) // If the assigned weapon is not null. GK
        {
            assignedWeapon.LevelUp(); // Level up the weapon. GK
            UIController.instance.levelUpPanel.SetActive(false); // Set the level up panel to false. GK
            Time.timeScale = 1f; // Set the time scale to 1. GK
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
