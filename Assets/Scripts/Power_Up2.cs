using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Power_Up2 : MonoBehaviour
{
    public Player script;
    public AudioSource PowerUp_Sound;
    
    private void OnTriggerEnter(Collider other)
    {
        // POWERUP: player gets +2 lives on collision with potion
        if (other.CompareTag("Player3"))
        {
            // Detroy the potion
            Destroy(this.gameObject);
            // Power up: add two lives to the player
            other.GetComponent<Player>().PowerUp();
            PowerUp_Sound.Play();
        }
    }

}

