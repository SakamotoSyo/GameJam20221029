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
    [SerializeField] float _maxTime;
    private Text _resultTimeText;
    protected override bool _dontDestroyOnLoad { get{ return true; } }
    /// <summary>アプリケーションの終了</summary>
    public void EndGame()
    {
        Application.Quit();
    }
    /// <summary>シーンのロード(Coroutimeにより3秒の遅延)</summary>
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
    /// <summary>スコアをインスタンス化したスクリプトへ移動</summary>
    /// <param name="score"></param>
    public void Temp(float score,float time)
    {
        _tempScore = score;
        _time = _maxTime - time;
    }
    /// <summary>リザルトシーンの際、スコアの表示(スコアがなければ後で消す。)</summary>
    /// <param name="level"></param>
    private void OnLevelWasLoaded(int level)
    {
        _resultScoreText = GameObject.FindGameObjectWithTag("Respawn").GetComponent<Text>();
        if (_resultScoreText) _resultScoreText.text = _tempScore.ToString("D7");
        _resultTimeText = GameObject.FindGameObjectWithTag("Finish").GetComponent<Text>();
        if (_resultTimeText) _resultTimeText.text = string.Format("{0:00.00}", _time);
    }
}
