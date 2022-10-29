using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class EnemyScript : MonoBehaviour
{
    [Header("キャラクターのスピード")]
    [SerializeField] int _speed = 0;
    [Header("回転にかける時間")]
    [SerializeField] int _rotationTime = 0;

    [Tooltip("敵が向いている方向")] Vector2 _dir;
    [Tooltip("現在回転中かどうか")] bool _isWait = false;
    Rigidbody2D _rb;
    int[] _rotateArray = { 0, 90, 180, 270 };
    Vector2[] _dirArray = { new Vector2(0, -1), new Vector2(-1, 0), new Vector2(0, 1), new Vector2(1, 0) };
    Coroutine _rotationCor;
    WaitForSeconds _time;

    void Start()
    {
        _dir = new Vector2(0, -1);
        _rb = GetComponent<Rigidbody2D>();
        _time = new WaitForSeconds(_rotationTime);
    }

    void Update()
    {

    }

    void FixedUpdate()
    {
        if (!_isWait)
        {
            //下方向にRayをだす
            RaycastHit2D hit = Physics2D.Raycast(transform.position, _dir, 1);
            Debug.DrawRay(transform.position, _dir, Color.red);
            if (hit.collider != null)
            {
                if (_rotationCor == null && hit.collider.tag == "Wall")
                {
                    Debug.Log("入っている");
                    _rotationCor = StartCoroutine(EnemyWait());
                }
            }

            _rb.velocity = _dir.normalized * _speed;
        }
        else 
        {
            _rb.velocity = Vector2.zero;
        }
    }

    IEnumerator EnemyWait()
    {
        //次進む方向をランダムに選ぶ
        var num = Random.Range(0, _rotateArray.Length);
        //壁に当たった時一定時間待つ
        _isWait = true;
        yield return _time;
        //別の方向に移動する
        _dir = _dirArray[num];
        _isWait = false;
        _rotationCor = null;


    }
}
