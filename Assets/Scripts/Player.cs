using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float _speed = 5f;
    private float _jumpingSpeed = 10;

    [SerializeField]
    private Rigidbody RB;

    [SerializeField]
    private GameObject _pizzaBulletPrefab;
    
    [SerializeField]
    private GameObject _spawnManager;

    [SerializeField]
    private UI_Manager _uiManager;

    private float _nextJumpTime = 0f;
    private float _coolDownTime = 1.5f;
    private float _shootCoolDowntime = 0f;
    private float _nextShootTime = 0.5f;

    private int _lives = 5;
    
    void Start()
    {
        // UPDATE LIVES
        _uiManager.UpdateLives(_lives);

        transform.position = new Vector3(0f, 0f, 0f); // The player starts in the middle of the scene.
    }

    
    void Update()
    {
       PlayerMovement();
       
       if (Input.GetKeyDown(KeyCode.X) && _nextShootTime < Time.time)
        {
            Instantiate(_pizzaBulletPrefab, transform.position + new Vector3(0f, 0.7f, 0f), Quaternion.identity);
            _nextShootTime = Time.time + _shootCoolDowntime;
        }   
    }
    
    public void Damage()
    { 
        //UPDATE LIVES: damage reduces our lives
        _lives --;
        _uiManager.UpdateLives(_lives);
        Debug.Log("Damage"+ _lives);

        //DEATH
        if (_lives == 0)
        {
            Debug.Log("Death");

            if (_spawnManager != null)
            {
                _spawnManager.GetComponent<Spawn_Manager>().onPlayerDeath();
                Destroy(this.gameObject);
            }
            else
            {
                Debug.LogError("Spawn_Manager not assigned");
            }
            
            // STOP SPAWNING when player dies
            _spawnManager.GetComponent<Spawn_Manager>().onPlayerDeath();
            Destroy(this.gameObject);

            // Delets the enemies in the hierarchy
            foreach (Transform child in _spawnManager.transform)
            {
                Destroy(child.gameObject);

            }
        }   
    }
    
    void PlayerMovement()
    {
         // JUMPING (applying jumping speed to rigidbody)
        if (Input.GetKeyDown("space") && _nextJumpTime < Time.time)
        {
            // Debug.Log("we want to jump");
            RB.velocity += new Vector3(0f, _jumpingSpeed, 0f);
            _nextJumpTime = Time.time + _coolDownTime; 
        }
    

        // HORIZONTAL MOVEMENT 
        float horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * Time.deltaTime * _speed * horizontalInput);

        // before the player reaches -10 (y axis) we teleport it back
        if (transform.position.y < -10f)
        {
            // TELEPORT back to this position
            transform.position = new Vector3(0f, 1f, 0f);
        }
    }
    
}