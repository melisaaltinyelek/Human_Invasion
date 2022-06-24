using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Power_Up : MonoBehaviour
{   
    public Player script;
    public AudioSource PowerUp_Sound;
    
    // POWERUP: player gets +2 lives on collision with potion
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player2"))
        {
            // Detroy the potion
            Destroy(this.gameObject);
            // Power up: add two lives to the player
            other.GetComponent<Player>().PowerUp();
            PowerUp_Sound.Play();
            
        }
    }

    
}

