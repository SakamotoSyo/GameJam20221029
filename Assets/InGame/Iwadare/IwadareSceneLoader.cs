using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/// <summary>SceneLoaderのシングルトン</summary>
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
    /// <summary>アプリケーションの終了</summary>
    public void EndGame()
    {
        Application.Quit();
    }
    /// <summary>シーンのロード(Coroutimeにより3秒の遅延)</summary>
    /// <param name="_loadSceneName"></param>
    public void SceneLoad(string _loadSceneName)
    {
        StartCoroutine(SceneLoadStart(_loadSceneName, 3f));
    }
    /// <summary>0.5秒遅延するシーンのロード</summary>
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
    /// <summary>スコアをインスタンス化したスクリプトへ移動</summary>
    /// <param name="score"></param>
    public void Temp(float score, float time)
    {
        _tempScore = score;
        _time = _maxTime - time;
    }
    /// <summary>リザルトシーンの際、スコアの表示(スコアがなければ後で消す。)</summary>
    /// <param name="level"></param>
    private void OnLevelWasLoaded(int level)
    {
        Start();
    }
}
