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
}
