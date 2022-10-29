using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D _rb;
    [Header("���s���x"), SerializeField] float _walkSpeed = 10;
    /// <summary>Player�̃A�j���[�^�[</summary>
    Animator _anim;
    /// <summary>�����Ă��Ȃ��Ƃ��APlayer�̌����������Œ肷��</summary>
    Vector2 foward;
    GameManager GM;
    [Header("�G�̃^�O�������Ă�������"), SerializeField] string _enemyTag;
    [Header("�N���A����ƂȂ�I�u�W�F�N�g�̃^�O��"), SerializeField] string _clearTag;
    [Header("�X�R�A���_�ƂȂ�I�u�W�F�N�g�̃^�O��"), SerializeField] string _scoreTag;
    [Header("�X�R�A���_��"), SerializeField] int _score = 100;
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _anim = GetComponent<Animator>();

        GM = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
        GM.TimeOver += TimeOver;

        if (_enemyTag == "")
        {
            Debug.Log("Player�̃X�N���v�g�ɓG�̃^�O�������Ă�������");
        }
        else if (_clearTag == "")
        {
            Debug.Log("Player�̃X�N���v�g�ɃN���A����ƂȂ�I�u�W�F�N�g�̃^�O�������Ă�������");
        }
        else if (_scoreTag == "")
        {
            Debug.Log("Player�̃X�N���v�g�ɃX�R�A���_�ƂȂ�I�u�W�F�N�g�̃^�O�������Ă�������");
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
                //�����ړ�����Ƃ�Player�𔽓]
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
