using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn_Manager_L3 : MonoBehaviour
{
    [SerializeField]
    private GameObject _enemy_3Prefab;

    [SerializeField]
    private GameObject[] humans;

    [SerializeField]
    private UI_Manager _uiManager;
   
    private float _delay = 0.50f;
    private bool _alive = true;
    
    void Start()
    {
        StartCoroutine(SpawnSystem3());
    }

    // RETURNS RANDOM lIST INDEX to instantiate enemies
    private int GetRandomNumber3()

    {
        System.Random random = new System.Random();
        int randomNumber = random.Next(0, humans.Length);
        return randomNumber;
    }
    
    // GAME OVER text appears when player dies
    public void onPlayerDeath3()
    {
        _alive = false;
        _uiManager.gameOver();
    }
    
    // DEFINES how the enemies in level 3 are spawned
    IEnumerator SpawnSystem3()
    {
        while(_alive)
        {    // ASSIGN RANDOM ENEMYPREFAB
            _enemy_3Prefab = humans[GetRandomNumber3()];
            Instantiate(_enemy_3Prefab, new Vector3(Random.Range(-15f, 25f), 100f, 0), Quaternion.identity,this.transform);
            yield return new WaitForSeconds(_delay);
        } 

        yield return null;
    }
    
}
