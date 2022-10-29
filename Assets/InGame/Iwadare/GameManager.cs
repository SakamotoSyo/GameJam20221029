using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [Tooltip("時間を表示するテキスト")]
    [SerializeField] Text _time;
    [Tooltip("スコアを表示するテキスト")]
    [SerializeField] Text _scoreText;
    [Tooltip("時間")]
    [SerializeField] float _countDown = 100f;
    [Header("ゲームオーバーシーン(なかったらタイトルシーン)")]
    [Tooltip("ゲームオーバーシーン(なかったらタイトルシーン)")]
    [SerializeField] string _gameOverScene;
    [Header("ゲームクリアシーン")]
    [Tooltip("ゲームクリアシーン")]
    [SerializeField] string _gameCrearScene;
    [Tooltip("タイムオーバーの際のテキスト表示")]
    [SerializeField] GameObject _timeOverText;
    [Tooltip("幽霊につかまった際のテキスト表示")]
    [SerializeField] GameObject _catchPlayerText;
    [Tooltip("脱出した際のテキスト表示")]
    [SerializeField] GameObject _escapeText;
    [Tooltip("スコア")]
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
    /// <summary>スコアの追加のメソッド</summary>
    /// <param name="score"></param>
    public void AddScore(int score)
    {
        _score += score;
        _scoreText.text = string.Format("0000000", _score);
    }

    /// <summary>幽霊につかまった際のメソッド</summary>
    public void GameOver()
    {
        _catchPlayerText.SetActive(true);
        IwadareSceneLoader.Instance.SceneLoad(_gameOverScene);
    }
    /// <summary>脱出した際のメソッド</summary>
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
