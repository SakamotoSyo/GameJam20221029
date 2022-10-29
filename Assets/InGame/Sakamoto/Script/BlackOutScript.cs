using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackOutScript : MonoBehaviour
{
    [Header("�u���b�N�A�E�g����Ԋu")]
    [SerializeField] float _blackTime;
    [Header("FadeInOut�ɂ����鎞��")]
    [SerializeField] float _outIn;
    [SerializeField] FadeIn _fadeIn;
    [SerializeField] FadeOut _fadeOut;

    float _count = 0;
    bool _isblack;
    WaitForSeconds _time;

    void Start()
    {
        _time = new WaitForSeconds(_outIn);
    }

    void Update()
    {



        if (_isblack && _blackTime < _count)
        {
            _count = 0;
            StartCoroutine(Fade());
        }
        else
        {
            _count = Time.deltaTime;
        }
    }

    /// <summary>
    /// FadeInOut���鎞��
    /// </summary>
    /// <returns></returns>
    IEnumerator Fade()
    {
        _fadeIn.Fade(_outIn);
        yield return _time;
        _fadeOut.Fade(_outIn, false);
    }
}
