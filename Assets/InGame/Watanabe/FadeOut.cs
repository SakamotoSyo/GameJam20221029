using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FadeOut : MonoBehaviour
{
    [Tooltip("�t�F�[�h�p��Panel")]
    [SerializeField] Image _fadePanel;
    [Tooltip("�J�ڐ�̃V�[����")]
    [SerializeField] string _sceneName;
    float _fadeTime = 0f;

    // Start is called before the first frame update
    void Start()
    {
        _fadePanel.raycastTarget = false;
    }

    public void SceneLoad()
    {
        StartCoroutine(Fade(1.5f));
    }

    /// <summary>
    /// �t�F�[�h�A�E�g
    /// </summary>
    /// <param name="fadeTime">���s����</param>
    public IEnumerator Fade(float fadeTime, bool load = true)
    {
        Color color = _fadePanel.color;
        _fadePanel.color = color;

        while (_fadeTime <= fadeTime)
        {
            yield return null;
            _fadePanel.raycastTarget = true;
            //��TimeScale�ɍ��E����Ȃ�DeltaTime
            _fadeTime += Time.unscaledDeltaTime;
            color.a = _fadeTime / fadeTime;
            _fadePanel.color = color;

            if (color.a >= 1f)
            {
                color.a = 1f;
                if (load) 
                {
                    Load(_sceneName);
                }
            }
        }
    }

    void Load(string scenename)
    {
        SceneManager.LoadScene(scenename);
    }
}
