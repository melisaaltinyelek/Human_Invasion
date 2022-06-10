using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    [SerializeField]
    private Transform _followTarget;
    
    public Vector3 _camOffset;
    
    
    void Start()
    // 
    {
        _camOffset = transform.position - _followTarget.transform.position;
    }

    
    void LateUpdate()
    // 
    {
       if( _followTarget != null)
       {
            Vector3 newPosition = _followTarget.transform.position + _camOffset;
            transform.position = newPosition; 
        }
    }
}

