using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet_Rotation : MonoBehaviour
{
    [SerializeField]
    private Vector3 _rotation;
    public GameObject Player;

    // ROTATE planets
    void Update()
    {
        transform.Rotate(_rotation * Time.deltaTime);
    }
}

