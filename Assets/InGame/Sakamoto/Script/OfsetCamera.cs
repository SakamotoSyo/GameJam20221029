using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OfsetCamera : MonoBehaviour
{
    [Header("�J������OffSet")]
    [SerializeField] Vector3 _offset;

    [Tooltip("Player��Obj")] GameObject _playerObj;


    void Start()
    {
        Debug.Log("�m�F");
        _playerObj = GameObject.Find("Player(Clone)");    
    }

    void Update()
    {
        transform.position = _playerObj.transform.position + _offset;  
    }
}
