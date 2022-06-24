using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Egg : MonoBehaviour
{
    public Player script;
    public AudioSource Shrink_Sound;
    public void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Player3"))
        {

            // Destroys the egg
            Destroy(this.gameObject);
            // Shrink the player
            other.GetComponent<Player>().Shrink();
            Shrink_Sound.Play();

        }
    }    

}

