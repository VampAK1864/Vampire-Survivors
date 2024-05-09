using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public static UIController instance; // Create a singleton instance of the UIController. GK
    public void Awake()
    {
        instance = this; // Set the instance to this object. GK
    }
    public Slider explvlSlider; // The experience level slider. GK
    public TMP_Text explvlText; // The experience level text. GK

    public LevelUpSellectionButton[] levelUpButtons; // The level up buttons. GK

    public GameObject levelUpPanel; // The level up panel. GK
    public TMP_Text coinText; // The coin text. D
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void UpdateExperience(int currentExp, int levelExp, int currentLvl) // Function to update the experience. GK
    {
        explvlSlider.maxValue = levelExp; // Set the max value of the slider to the level experience. GK
        explvlSlider.value = currentExp; // Set the value of the slider to the current experience. GK
        explvlText.text = "Level: " + currentLvl; // Set the text to the current level and experience. GK
    }
    public void SkipLevelUp() // Function to skip the level. GK
    {
        levelUpPanel.SetActive(false); // Set the level up panel to false. GK
        Time.timeScale = 1f; // Set the timescale to 1. GK
    }
    
    public void UpdateCoins() // Function to update the coins. D
    {
        coinText.text = "Coins: " + CoinController.instance.currentCoins; // Set the coin text to the current coins. D
    }
}

