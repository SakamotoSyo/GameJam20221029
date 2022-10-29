using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackOutScript : MonoBehaviour
{
    [Header("ブラックアウトする間隔")]
    [SerializeField] float _blackTime;
    [Header("FadeInOutにかける時間")]
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
    /// FadeInOutする時間
    /// </summary>
    /// <returns></returns>
    IEnumerator Fade()
    {
        _fadeIn.Fade(_outIn);
        yield return _time;
        _fadeOut.Fade(_outIn, false);
    }
}
