using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private float _enemySpeed = 6;
    
    void Update()
    {
        // ENEMY SPEED on the y-axis
        transform.Translate(Vector3.down * _enemySpeed * Time.deltaTime);

        // ENEMY FALLS AT A RANDOM RANGE 
        if (transform.position.y < 2f)
        {
           transform.position = new Vector3(Random.Range(-10f, 35f), 110f, 0f);
        }
    }
     
    // CHECK THE COLLISION OF OBJECTS BY ACCESSING THEIR TAGS
    private void OnTriggerEnter(Collider other)
    {   
        if (other.CompareTag("Pizza_Bullet"))
        {
            // Destroys the enemy
            Destroy(this.gameObject);
            // Destroys the bullet
            Destroy(other.gameObject);
        }
        
        if (other.CompareTag("Player"))
        {
            // Destroys the enemy
            Destroy(this.gameObject);
            // Take damage
            other.GetComponent<Player>().Damage();

        }
        if (other.CompareTag("Player2"))
        {
            // Destroys the enemy
            Destroy(this.gameObject);
            // Take damage (1 life)
            other.GetComponent<Player>().Damage();
        }

    }
}
