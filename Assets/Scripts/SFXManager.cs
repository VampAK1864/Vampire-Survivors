using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXManager : MonoBehaviour
{
    public static SFXManager instance; // Singleton. GK

    public void Awake() // GK
    {
        instance = this; // GK
    }

    public AudioSource[] soundEffects; // The sound effects. GK 

    public void PlaySFX(int sfxToPlay) // Play the sound effect. GK
    {
        soundEffects[sfxToPlay].Stop(); // Stop the sound effect. GK
        soundEffects[sfxToPlay].Play(); // Play the sound effect. GK
    }
    public void PlaySFXPitched(int sfxToPlay) // Play the sound effect with pitch. GK
    {
        soundEffects[sfxToPlay].pitch = Random.Range(.8f,1.2f); // Set the pitch. GK
        PlaySFX(sfxToPlay); // Play the sound effect. GK
    }
}