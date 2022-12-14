using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OfsetCamera : MonoBehaviour
{
    [Header("カメラのOffSet")]
    [SerializeField] Vector3 _offset;

    [Tooltip("PlayerのObj")] GameObject _playerObj;


    void Start()
    {
        Debug.Log("確認");
        _playerObj = GameObject.Find("Player(Clone)");    
    }

    void Update()
    {
        transform.position = _playerObj.transform.position + _offset;  
    }
}
