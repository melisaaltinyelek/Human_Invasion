using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Space_Ship : MonoBehaviour
{

    [SerializeField]
    private Animator myAnimation;

    public AudioSource SpaceShip_Sound;

    // Start animation of spaceship on player's collision 
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player3"))
            
        {
            myAnimation.SetBool("PlaySpin", true);
            // play sound effect as animation starts
            SpaceShip_Sound.Play();
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Player3"))
        {
            // Destroy player ("as it enters the spaceship")
            Destroy(other.gameObject);
            

        }

    }  
}

