using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>SceneLoaderのシングルトン</summary>
public class IwadareSceneLoader : SingletonMonovihair<IwadareSceneLoader>
{
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
}
