using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn_Manager_L2 : MonoBehaviour
{
    [SerializeField]
    private GameObject _enemy_2Prefab;

    [SerializeField]
    private GameObject[] humans;

    [SerializeField]
    private UI_Manager _uiManager;
   
    private float _delay = 0.65f;
    private bool _alive = true;
    
    void Start()
    {
        StartCoroutine(SpawnSystem2());
    }

    // RETURNS RANDOM lIST INDEX to instantiate enemies
    private int GetRandomNumber2()
    {
        System.Random random = new System.Random();
        int randomNumber = random.Next(0, humans.Length);
        return randomNumber;
    }
    
    // GAME OVER text appears when player dies
    public void onPlayerDeath2()
    {
        _alive = false;
        _uiManager.gameOver();
    }
    
    // DEFINES how the enemies in level 2 are spawned
    IEnumerator SpawnSystem2()
    {
        while(_alive)
        {    // ASSIGN RANDOM ENEMYPREFAB
            _enemy_2Prefab = humans[GetRandomNumber2()];
            Instantiate(_enemy_2Prefab, new Vector3(Random.Range(-15f, 20f), 50f, 0), Quaternion.identity,this.transform);
            yield return new WaitForSeconds(_delay);
        } 

        yield return null;
    }
    
}
