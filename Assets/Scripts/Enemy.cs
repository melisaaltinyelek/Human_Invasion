using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private float _enemySpeed = 10;
    
    void Update()
    {
        // ENEMY SPEED on the y-axis
        transform.Translate(Vector3.down * _enemySpeed * Time.deltaTime);

        // ENEMY FALLS AT A RANDOM RANGE 
        if (transform.position.y < -10f)
        {
           transform.position = new Vector3(Random.Range(-15.5f, 23f), 55f, 0f);
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
            other.GetComponent<Player>().Damage();
        }
    }
}
