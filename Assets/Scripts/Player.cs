using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
    private float _coolDownTime = 1.25f;
    private float _shootCoolDowntime = 0f;
    private float _nextShootTime = 0.5f;
    
    public int _maxSouls = 10;
    public int _currentSouls;

    public Slider_Script _soulBar;

    public AudioSource Damage_Sound;

    
    void Start()
    {
        // LIVES OF PLAYER are maximum at the beginning of the game
        _currentSouls = _maxSouls;
        // LIVES OF PLAYER are represented as the soulbar
        _soulBar.SetMaxSouls(_maxSouls);
        
    }
    
    void Update()
    {
       PlayerMovement();
       
       // SHOOTING OF BULLETS
       if (Input.GetKeyDown(KeyCode.X) && _nextShootTime < Time.time)
        {
            Instantiate(_pizzaBulletPrefab, transform.position + new Vector3(0f, 0.7f, 0f), Quaternion.identity);
            _nextShootTime = Time.time + _shootCoolDowntime;

        }  
    }   
    
    // DAMAGE FOR LEVEL 1
    public void Damage()
    { 
        Damage_Sound.Play();
        // Enemies take -1 life.
        _currentSouls = _currentSouls -1;

        
        //Debug.Log("Damage"+ _currentSouls);
        _soulBar.SetSouls(_currentSouls);

        //DEATH
        if (_currentSouls == 0)
        {
            // Debug.Log("Death");
            

            if (_spawnManager != null)
            {
                _spawnManager.GetComponent<Spawn_Manager>().onPlayerDeath();
                Destroy(this.gameObject);
            }
            //else
            //{
                // Debug.LogError("Spawn_Manager not assigned");
            //}
            
            // STOP SPAWNING when player dies
            _spawnManager.GetComponent<Spawn_Manager>().onPlayerDeath();
            Destroy(this.gameObject);

            // Deletes the enemy-clones in the hierarchy
            foreach (Transform child in _spawnManager.transform)
            {
                Destroy(child.gameObject);

            }
        }   
    }

    //DAMAGE FOR LEVEL 2 and 3
    public void Damage2()
    { 
        Damage_Sound.Play();
        // Enemies take -2 life.
        _currentSouls = _currentSouls -2;

        
        //Debug.Log("Damage"+ _currentSouls);
        _soulBar.SetSouls(_currentSouls);

        //DEATH
        if (_currentSouls == 0)
        {
            //Debug.Log("Death");

            if (_spawnManager != null)
            {
                _spawnManager.GetComponent<Spawn_Manager_L2>().onPlayerDeath2();
                Destroy(this.gameObject);
            }
            // else
            // {
            //     Debug.LogError("Spawn_Manager not assigned");
            // }
            
            // STOP SPAWNING when player dies
            _spawnManager.GetComponent<Spawn_Manager_L2>().onPlayerDeath2();
            Destroy(this.gameObject);

            // Delets the enemy-clones in the hierarchy
            foreach (Transform child in _spawnManager.transform)
            {
                Destroy(child.gameObject);

            }
        }   
    }

    public void Damage3()
    { 
        Damage_Sound.Play();
        // Enemies take -2 life.
        _currentSouls = _currentSouls -2;

        
        //Debug.Log("Damage"+ _currentSouls);
        _soulBar.SetSouls(_currentSouls);

        //DEATH
        if (_currentSouls == 0)
        {
            //Debug.Log("Death");

            if (_spawnManager != null)
            {
                _spawnManager.GetComponent<Spawn_Manager_L3>().onPlayerDeath3();
                Destroy(this.gameObject);
    
            }
            // else
            // {
            //     Debug.LogError("Spawn_Manager not assigned");
            // }
            
            // STOP SPAWNING when player dies
            _spawnManager.GetComponent<Spawn_Manager_L3>().onPlayerDeath3();
            Destroy(this.gameObject);

            // Delets the enemy-clones in the hierarchy
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

        // Define teleport of the player for each level
        
        //Before the player reaches -1 (y axis) we teleport it back

        if (gameObject.tag == "Player" && transform.position.y < 1f)
        {
            // TELEPORT back to this position
            transform.position = new Vector3(0f, 10f, 0f);
        }

        if (gameObject.tag == "Player2" && transform.position.y < 1f)
        {
            // TELEPORT back to this position
            transform.position = new Vector3(0f, 16f, 0f);
        }
        
        if (gameObject.tag == "Player3" && transform.position.y < 1f)   
        {
            // TELEPORT back to this position
            transform.position = new Vector3(0f, 16f, 0f);
        }

    }
    

    public void PowerUp()
    { 
        // Player takes +2 lives
        _currentSouls = _currentSouls + 2;
        // Lives get updated in soulbar
        _soulBar.SetSouls(_currentSouls);
        
        // Debug.Log("PowerUp"+ _currentSouls);

    }

    public void Shrink ()
    {
        // Player's scale gets minimized
        transform.localScale = new Vector3(0.6f, 0.4f, 0.1f);
        // Debug.Log ("Shrink");

    }

    public void DeShrink()
    {
        // Player's scale gets maximized 
        transform.localScale = new Vector3 (0.92045f, 0.6920175f, 1.240527f);
        

    }

}