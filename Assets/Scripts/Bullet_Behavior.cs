using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_Behavior : MonoBehaviour
{
   private float _pizzaBulletSpeed = 5f;
   
    void Update()
    {
        // PlAYER SHOOTING UPWARDS
        transform.Translate(Vector3.up * _pizzaBulletSpeed * Time.deltaTime);
        
        //DESTROY - Destruction of the bullet once a certain height has been reached
        if (transform.position.y > 55f)
        {
            Destroy(this.gameObject);
        }   
    }
}