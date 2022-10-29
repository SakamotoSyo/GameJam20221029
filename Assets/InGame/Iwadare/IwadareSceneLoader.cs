using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IwadareSceneLoader : SingletonMonovihair<IwadareSceneLoader>
{
    protected override bool _dontDestroyOnLoad { get{ return true; } }

    public void EndGame()
    {
        Application.Quit();
    }

    public void SceneLoad(string _loadSceneName)
    {
        StartCoroutine(SceneLoadStart(_loadSceneName));
    }
    
    IEnumerator SceneLoadStart(string _loadSceneName)
    {
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene(_loadSceneName);
    }
}
