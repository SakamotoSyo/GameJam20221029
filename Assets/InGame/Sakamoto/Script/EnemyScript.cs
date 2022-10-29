using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class EnemyScript : MonoBehaviour
{
    [Header("�L�����N�^�[�̃X�s�[�h")]
    [SerializeField] int _speed = 0;
    [Header("��]�ɂ����鎞��")]
    [SerializeField] int _rotationTime = 0;

    [Tooltip("�G�������Ă������")] Vector2 _dir;
    [Tooltip("���݉�]�����ǂ���")] bool _isWait = false;
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
            //��������Ray������
            RaycastHit2D hit = Physics2D.Raycast(transform.position, _dir, 1);
            Debug.DrawRay(transform.position, _dir, Color.red);
            if (hit.collider != null)
            {
                if (_rotationCor == null && hit.collider.tag == "Wall")
                {
                    Debug.Log("�����Ă���");
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
        //���i�ޕ����������_���ɑI��
        var num = Random.Range(0, _rotateArray.Length);
        //�ǂɓ�����������莞�ԑ҂�
        _isWait = true;
        yield return _time;
        //�ʂ̕����Ɉړ�����
        _dir = _dirArray[num];
        _isWait = false;
        _rotationCor = null;


    }
}
