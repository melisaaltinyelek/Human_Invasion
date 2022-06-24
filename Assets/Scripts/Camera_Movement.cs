using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Movement : MonoBehaviour
{

    [SerializeField]
    private Transform _followTarget;
    
    public Vector3 offset;

    void Start()
    {
        // Set camera to follow the player
        offset = transform.position - _followTarget.transform.position;
    }

    void LateUpdate()
    {
        // Null Check
        if(_followTarget != null)
        {
        // Add offset to the position in order to depict the player properly.
        Vector3 newPosition = _followTarget.transform.position + offset;
        transform.position = newPosition;
        }
    }
}
