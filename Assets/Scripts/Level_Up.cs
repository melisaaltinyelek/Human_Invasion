using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Level_Up : MonoBehaviour
{

    public AudioSource LevelUp;
    // SWITCH TO NEXT LEVEL
    private void OnTriggerEnter(Collider other)
    {   
        // when player collides with heart object
        if (other.CompareTag("Player"))
        {
            SceneManager.LoadScene(2);
            LevelUp.Play();
        }

        // when player collides with heart object
        if (other.CompareTag("Player2"))
        {
            SceneManager.LoadScene(3);
            LevelUp.Play();
        }
    }

}



