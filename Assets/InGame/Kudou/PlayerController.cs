using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D _rb;
    [Header("歩行速度"), SerializeField] float _walkSpeed = 10;
    /// <summary>Playerのアニメーター</summary>
    Animator _anim;
    /// <summary>動いていないとき、Playerの向く方向を固定する</summary>
    Vector2 foward;
    GameManager GM;
    [Header("敵のタグ名を入れてください"), SerializeField] string _enemyTag;
    [Header("クリア判定となるオブジェクトのタグ名"), SerializeField] string _clearTag;
    [Header("スコア加点となるオブジェクトのタグ名"), SerializeField] string _scoreTag;
    [Header("スコア加点数"), SerializeField] int _score = 100;
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _anim = GetComponent<Animator>();

        GM = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
        GM.TimeOver += TimeOver;

        if (_enemyTag == "")
        {
            Debug.Log("Playerのスクリプトに敵のタグ名を入れてください");
        }
        else if (_clearTag == "")
        {
            Debug.Log("Playerのスクリプトにクリア判定となるオブジェクトのタグ名を入れてください");
        }
        else if (_scoreTag == "")
        {
            Debug.Log("Playerのスクリプトにスコア加点となるオブジェクトのタグ名を入れてください");
        }
    }


    void Update()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        if (x != 0 || y != 0)
        {
            foward = new Vector2(x, y);
        }

        _rb.velocity = new Vector2(x * _walkSpeed, y * _walkSpeed);

        if (_rb.velocity.magnitude != 0)
        {
            _anim.SetBool("Walk", true);
            _anim.SetFloat("Walk.y", _rb.velocity.y);
            _anim.SetFloat("Walk.x", _rb.velocity.x);
            if (_rb.velocity.x < 0)
            {
                //左横移動するときPlayerを反転
                transform.rotation = Quaternion.Euler(0, 180, 0);
            }
            if (_rb.velocity.x > 0)
            {
                transform.rotation = Quaternion.Euler(0, 0, 0);
            }
        }
        else
        {
            _anim.SetBool("Walk", false);
            _anim.SetFloat("Idle.y", foward.y);
            _anim.SetFloat("Idle.x", foward.x);
        }
    }

    void TimeOver() 
    {
        _walkSpeed = 0;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(_enemyTag))
        {
            GM.GameOver();
            _walkSpeed = 0;
        }
        else if (collision.gameObject.CompareTag(_clearTag))
        {
            GM.EscapeText();
            _walkSpeed = 0;
        }
        else if (collision.gameObject.CompareTag(_scoreTag))
        {
            GM.AddScore(_score);
        }
    }
}
