using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OfsetCamera : MonoBehaviour
{
    [Header("ÉJÉÅÉâÇÃOffSet")]
    [SerializeField] Vector3 _offset;

    [Tooltip("PlayerÇÃObj")] GameObject _playerObj;


    void Start()
    {
        Debug.Log("ämîF");
        _playerObj = GameObject.Find("Player(Clone)");    
    }

    void Update()
    {
        transform.position = _playerObj.transform.position + _offset;  
    }
}
