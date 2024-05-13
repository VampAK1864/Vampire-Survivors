using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance; // Singleton. GK
    public void Awake() // GK
    {
        instance = this; // GK
    }
    private bool gameActive; // The game is active. GK

    public float timer;
    public float waitToShowEndScreen = 1f;
    // Start is called before the first frame update
    void Start()
    {
        gameActive = true; // The game is active. GK
    }

    // Update is called once per frame
    void Update()
    {
        if (gameActive) // If the game is active. GK
        {
            timer += Time.deltaTime; // Add the time. GK
            UIController.instance.UpdateTimer(timer); // Update the timer. GK
        }
    }
    public void EndLevel() // End the level. GK
    {
        gameActive = false; // The game is not active. GK
        StartCoroutine(EndLevelCo()); // Start the coroutine. GK

    }
    
    IEnumerator EndLevelCo() // Coroutine to end the level. GK
    {
        yield return new WaitForSeconds(waitToShowEndScreen); // Wait for 1 second. GK
        float minutes = Mathf.FloorToInt(timer / 60); // The minutes. GK
        float seconds = Mathf.FloorToInt(timer % 60); // The seconds. GK
        UIController.instance.endTimeText.text = minutes.ToString() + " mins " + seconds.ToString("00" + " secs"); // Set the end time text. GK
        UIController.instance.levelEndScreen.SetActive(true); // Set the end panel to active. GK
    }
}
