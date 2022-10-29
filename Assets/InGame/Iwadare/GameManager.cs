using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [Tooltip("���Ԃ�\������e�L�X�g")]
    [SerializeField] Text _time;
    [Tooltip("�X�R�A��\������e�L�X�g")]
    [SerializeField] Text _scoreText;
    [Tooltip("����")]
    [SerializeField] float _countDown = 100f;
    [Header("�Q�[���I�[�o�[�V�[��(�Ȃ�������^�C�g���V�[��)")]
    [Tooltip("�Q�[���I�[�o�[�V�[��(�Ȃ�������^�C�g���V�[��)")]
    [SerializeField] string _gameOverScene;
    [Header("�Q�[���N���A�V�[��")]
    [Tooltip("�Q�[���N���A�V�[��")]
    [SerializeField] string _gameCrearScene;
    [Tooltip("�^�C���I�[�o�[�̍ۂ̃e�L�X�g�\��")]
    [SerializeField] GameObject _timeOverText;
    [Tooltip("�H��ɂ��܂����ۂ̃e�L�X�g�\��")]
    [SerializeField] GameObject _catchPlayerText;
    [Tooltip("�E�o�����ۂ̃e�L�X�g�\��")]
    [SerializeField] GameObject _escapeText;
    [Tooltip("�X�R�A")]
    int _score = 0;
    // Start is called before the first frame update
    void Start()
    {
        AddScore(0);
    }

    // Update is called once per frame
    void Update()
    {
        if (_time)
        {
            _time.text = string.Format("{0:00.00}", _countDown);
            _countDown = Mathf.Max(0f, _countDown - Time.deltaTime);
        }
        if(_countDown <= 0)
        {
            _timeOverText.SetActive(true);
            IwadareSceneLoader.Instance.SceneLoad(_gameOverScene);
        }
        
    }
    /// <summary>�X�R�A�̒ǉ��̃��\�b�h</summary>
    /// <param name="score"></param>
    public void AddScore(int score)
    {
        _score += score;
        _scoreText.text = string.Format("0000000", _score);
    }

    /// <summary>�H��ɂ��܂����ۂ̃��\�b�h</summary>
    public void GameOver()
    {
        _catchPlayerText.SetActive(true);
        IwadareSceneLoader.Instance.SceneLoad(_gameOverScene);
    }
    /// <summary>�E�o�����ۂ̃��\�b�h</summary>
    public void EscapeText()
    {
        _escapeText.SetActive(true);
        IwadareSceneLoader.Instance.Temp(_score);
        IwadareSceneLoader.Instance.SceneLoad(_gameCrearScene);
    }
    private void OnLevelWasLoaded(int level)
    {
        //_countDown = 100f;
    }
}
