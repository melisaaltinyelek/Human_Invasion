using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeShrink : MonoBehaviour
{
    public Player script;
  
    // Deshrink player on collision with fellow alien
    public void OnTriggerEnter(Collider other)
    {   

        if (other.CompareTag("Player3"))
        {
            
            // Destroys the fellow alien (insect)
            Destroy(this.gameObject);
            // Deshrink the player
            other.GetComponent<Player>().DeShrink();
        
        }
    }

}
