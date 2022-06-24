using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class UI_Manager : MonoBehaviour
{
    public AudioSource Gameover;
    public AudioSource BackgroundMusic;

    // [SerializeField]
    // private TextMeshProUGUI _statustext;

    
    // ADD GAMEOVER TEXT
    public void gameOver()
    {
        // _statustext.text = "Humans have captured you!";
        // Stop background audio when player dies
        BackgroundMusic.Stop();
        // Play gameover audio when player dies
        Gameover.Play();

    }


}