using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

/// <summary>文字列からステージを生成する</summary>
public class ObjectConverter : MonoBehaviour
{
    [System.Serializable]
    struct StageObject
    {
        public GameObject obj;
        public char key;
    }

    [SerializeField] StageObject[] _stageObjects;
    [SerializeField] int _width = 13;
    [SerializeField] int _height = 13;
    StringGenerate _stringGenerate;

    Dictionary<char, GameObject> _tileDic = new Dictionary<char, GameObject>();

    void Awake()
    {
        _stringGenerate = GetComponent<StringGenerate>();

        foreach (StageObject so in _stageObjects)
            _tileDic.Add(so.key, so.obj);

        Generate();
    }

    void Start()
    {
        
    }

    void Update()
    {
#if UNITY_EDITOR
        // デバッグのためエディター上ではRキーでリロードできる
        if (Input.GetKeyDown(KeyCode.R))
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
        }
#endif
    }

    public void Generate()
    {
        string[] lines = _stringGenerate.Generate(_height, _width).Split('\n');

        // 注意:ジャグ配列には対応していない
        for (int i = 0; i < lines.Length; i++)
        {
            for (int j = 0; j < lines[0].Length; j++)
            {
                if(_tileDic.TryGetValue(lines[i][j], out GameObject value))
                {
                    Instantiate(value, new Vector3(i * 1.28f - (_width / 2), j * 1.28f - (_height / 2) - 1.75f, 0), Quaternion.identity);
                }
                else
                {
                    Debug.LogError(lines[i][j] + "が見つかりませんでした。タイルを生成できません。");
                }
            }
        }
    }
}
