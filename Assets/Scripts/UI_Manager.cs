using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class UI_Manager : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _livestext;

    [SerializeField]
    private TextMeshProUGUI _statustext;

    
    // ADD GAMEOVER TEXT
    public void gameOver()
    {
        _statustext.text = "Game Over!";
    }

    public void UpdateLives(int health)
    {
        // UPDATE TEXT
        _livestext.text = "Lives: " + health;
    }

}