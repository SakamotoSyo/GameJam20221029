using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// オブジェクトをランダムに回転させたりずらしたりする
/// </summary>
public class Randomaiser : MonoBehaviour
{
    [SerializeField] float _offsetX;
    [SerializeField] float _offsetY;

    void Start()
    {
        Vector3 vec = transform.position;
        vec.x += Random.Range(-_offsetX, _offsetX);
        vec.y += Random.Range(-_offsetY, _offsetY);
        transform.position = vec;

        float rotZ = Random.Range(0, 361);
        transform.eulerAngles = new Vector3(0, 0, rotZ);
    }

    void Update()
    {
        
    }
}
