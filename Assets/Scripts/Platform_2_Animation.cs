using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform_2_Animation : MonoBehaviour
{
    public GameObject Player;

    // ATTACH PLAYER TO PLATFORM
    private void OnTriggerEnter(Collider other)
    { 
        // setting player as a child of the platform on collision
        if (other.gameObject == Player)
        {
            Player.transform.parent = transform;
        }

    }

    private void OnTriggerExit(Collider other)
    {
        // resetting player to its original position in the hierarchy
        if (other.gameObject == Player)
        {
            Player.transform.parent = null;
        }
    }

}


