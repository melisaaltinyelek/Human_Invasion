using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn_Manager : MonoBehaviour
{
    [SerializeField]
    private GameObject _enemy_1Prefab;

    [SerializeField]
    private GameObject[] humans;

    [SerializeField]
    private UI_Manager _uiManager;
   
    private float _delay = 1f;
    private bool _alive = true;
    
    void Start()
    {
        StartCoroutine(SpawnSystem());
    }

    // RETURNS RANDOM lIST INDEX to instantiate enemies
    private int GetRandomNumber()

    {
        System.Random random = new System.Random();
        int randomNumber = random.Next(0, humans.Length);
        return randomNumber;
    }
    
    // GAME OVER text appears when player dies
    public void onPlayerDeath()
    {
        _alive = false;
        _uiManager.gameOver();
    }
    
    // DEFINES how the enemies in level 1 are spawned
    IEnumerator SpawnSystem()
    {
        while(_alive)
        {    // ASSIGN RANDOM ENEMYPREFAB
            _enemy_1Prefab = humans[GetRandomNumber()];
            Instantiate(_enemy_1Prefab, new Vector3(Random.Range(-15f, 20f), 50f, 0), Quaternion.identity,this.transform);
            yield return new WaitForSeconds(_delay);
        } 

        yield return null;
    }
    
}
