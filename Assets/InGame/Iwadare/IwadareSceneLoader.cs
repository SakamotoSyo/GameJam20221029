using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/// <summary>SceneLoader�̃V���O���g��</summary>
public class IwadareSceneLoader : SingletonMonovihair<IwadareSceneLoader>
{
    float _tempScore;
    Text _resultScoreText;
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
    /// <summary>�X�R�A���C���X�^���X�������X�N���v�g�ֈړ�</summary>
    /// <param name="score"></param>
    public void Temp(float score)
    {
        _tempScore = score;
    }
    /// <summary>���U���g�V�[���̍ہA�X�R�A�̕\��(�X�R�A���Ȃ���Ό�ŏ����B)</summary>
    /// <param name="level"></param>
    private void OnLevelWasLoaded(int level)
    {
        _resultScoreText = GameObject.FindGameObjectWithTag("Respawn").GetComponent<Text>();
        if (_resultScoreText) _resultScoreText.text = _tempScore.ToString("D7");
    }
}
