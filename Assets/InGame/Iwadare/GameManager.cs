using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] Text _time;
    [SerializeField] float _countDown = 100f;
    [SerializeField] string _sceneLoadName;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _time.text = string.Format("{0:00.00}" ,_countDown);
    }
}
