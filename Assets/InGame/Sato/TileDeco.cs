using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ランダムにタイルを装飾する
/// </summary>
public class TileDeco : MonoBehaviour
{
    [SerializeField] GameObject _decoPrefab;
    [Range(0, 100), SerializeField] float _prob;

    void Awake()
    {
        if (_decoPrefab == null)
        {
            Debug.LogWarning("タイルの装飾が割り当てられていません");
            return;
        }

        if (Random.Range(0, 100) > _prob - 1)
        {
            _decoPrefab.SetActive(false);
        }
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
