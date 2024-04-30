using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExperienceLevelController : MonoBehaviour
{
    public static ExperienceLevelController instance; // Create a singleton instance of the ExperienceLevelController. GK
    public void Awake()
    {
        instance = this; // Set the instance to this object. GK
    }

    public int currentExperience; // The current experience of the player. GK 

    public ExpPickup pickup; // The experience pickup. GK
    public List<int> expLevels; // The list of experience levels. GK
    public int currentLevel = 1, levelCount = 100; // The current level of the player. GK
    
    // Start is called before the first frame update
    void Start()
    {
        while (expLevels.Count < levelCount)    // While the experience levels are less than the level count. GK
        {
            expLevels.Add(Mathf.CeilToInt(expLevels[expLevels.Count-1]*1.1f)); // Add the experience levels to the list. GK
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GetExp(int amountToGet) // Function to get experience. GK
    {
        currentExperience += amountToGet; // Add the amount to the current experience. GK
        if(currentExperience >= expLevels[currentLevel]) // If the current experience is greater than or equal to the experience levels. GK
        {
            LevelUp(); // Level up the player. GK
        }
        UIController.instance.UpdateExperience(currentExperience, expLevels[currentLevel], currentLevel); // Update the experience. GK
    }

    public void SpawnExp(Vector3 position, int expValue) // Function to spawn experience into the world. GK
    {
        Instantiate(pickup, position, Quaternion.identity).expValue = expValue; // Instantiate the experience at the position. GK 
    }
    private void LevelUp() // Function to level up the player. GK
    {
        currentExperience -= expLevels[currentLevel]; // Subtract the experience levels from the current experience. GK         
        currentLevel++; // Increase the current level. GK
        if(currentLevel >= expLevels.Count) // If the current level is greater than or equal to the level count. GK
        {
            currentLevel = expLevels.Count-1; // Set the current level to the level count. GK
        }
        //PlayerController.instance.activeWeapon.LevelUp(); // Level up the player's weapon. GK
        UIController.instance.levelUpPanel.SetActive(true); // Set the level up panel to active. GK
        Time.timeScale = 0f; // Set the time scale to 0. GK
        UIController.instance.levelUpButtons[1].UpdateButtonDisplay(PlayerController.instance.activeWeapon); // Update the button display. GK
        
    }
}
