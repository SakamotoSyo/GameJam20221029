using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/// <summary>SceneLoader�̃V���O���g��</summary>
public class IwadareSceneLoader : SingletonMonovihair<IwadareSceneLoader>
{
    float _tempScore;
    private Text _resultScoreText;
    float _time;
    [SerializeField] float _maxTime = 100;
    private Text _resultTimeText;
    protected override bool _dontDestroyOnLoad { get { return true; } }

    void Start()
    {

        _resultScoreText = GameObject.FindGameObjectWithTag("Respawn")?.GetComponent<Text>();
        if (_resultScoreText) _resultScoreText.text = _tempScore.ToString("0000000");
        _resultTimeText = GameObject.FindGameObjectWithTag("Finish")?.GetComponent<Text>();
        if (_resultTimeText) _resultTimeText.text = string.Format("{0:00.00}", _time);
    }
    /// <summary>�A�v���P�[�V�����̏I��</summary>
    public void EndGame()
    {
        Application.Quit();
    }
    /// <summary>�V�[���̃��[�h(Coroutime�ɂ��3�b�̒x��)</summary>
    /// <param name="_loadSceneName"></param>
    public void SceneLoad(string _loadSceneName)
    {
        StartCoroutine(SceneLoadStart(_loadSceneName, 3f));
    }
    /// <summary>0.5�b�x������V�[���̃��[�h</summary>
    /// <param name="_loadSceneName"></param>
    public void TitleResultSceneLoad(string _loadSceneName)
    {
        StartCoroutine(SceneLoadStart(_loadSceneName, 0.5f));
    }

    IEnumerator SceneLoadStart(string _loadSceneName, float gameovertime)
    {
        yield return new WaitForSeconds(gameovertime);
        Debug.Log("GameOver");
        SceneManager.LoadScene(_loadSceneName);
    }
    /// <summary>�X�R�A���C���X�^���X�������X�N���v�g�ֈړ�</summary>
    /// <param name="score"></param>
    public void Temp(float score, float time)
    {
        _tempScore = score;
        _time = _maxTime - time;
    }
    /// <summary>���U���g�V�[���̍ہA�X�R�A�̕\��(�X�R�A���Ȃ���Ό�ŏ����B)</summary>
    /// <param name="level"></param>
    private void OnLevelWasLoaded(int level)
    {
        Start();
    }
}
