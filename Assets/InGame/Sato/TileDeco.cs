using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �����_���Ƀ^�C���𑕏�����
/// </summary>
public class TileDeco : MonoBehaviour
{
    [SerializeField] GameObject _decoPrefab;
    [Range(0, 100), SerializeField] float _prob;

    void Awake()
    {
        if (_decoPrefab == null)
        {
            Debug.LogWarning("�^�C���̑��������蓖�Ă��Ă��܂���");
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
