using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>SceneLoader�̃V���O���g��</summary>
public class IwadareSceneLoader : SingletonMonovihair<IwadareSceneLoader>
{
    protected override bool _dontDestroyOnLoad { get{ return true; } }
    /// <summary>�A�v���P�[�V�����̏I��</summary>
    public void EndGame()
    {
        Application.Quit();
    }
    /// <summary>�V�[���̃��[�h(Coroutime�ɂ��3�b�̒x��)</summary>
    /// <param name="_loadSceneName"></param>
    public void SceneLoad(string _loadSceneName)
    {
        StartCoroutine(SceneLoadStart(_loadSceneName));
    }

    IEnumerator SceneLoadStart(string _loadSceneName)
    {
        yield return new WaitForSeconds(3f);
        Debug.Log("GameOver");
        SceneManager.LoadScene(_loadSceneName);
    }
}
