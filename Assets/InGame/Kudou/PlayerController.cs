using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D _rb;
    [Header("ï‡çsë¨ìx"), SerializeField] float _walkSpeed = 10;
    Animator _anim;
    Vector2 foward;
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();  
        _anim = GetComponent<Animator>();
    }

    // Update is called once per frame
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
            _anim.SetBool("Walk",true);
            _anim.SetFloat("Walk.y", _rb.velocity.y);
            _anim.SetFloat("Walk.x", _rb.velocity.x);
            if (_rb.velocity.x < 0)
            {
                transform.rotation = Quaternion.Euler(0,180,0);
            }
            if (_rb.velocity.x > 0)
            {
                transform.rotation = Quaternion.Euler(0, 0, 0);
            }
        }
        else
        {
            _anim.SetBool("Walk",false);
            _anim.SetFloat("Idle.y", foward.y);
            _anim.SetFloat("Idle.x", foward.x);
        }
    }
}
