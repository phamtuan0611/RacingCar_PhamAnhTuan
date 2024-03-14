using System.Collections;
using System.Collections.Generic;
using GameTool;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class WinPopup : BaseUI
{
    // Start is called before the first frame update
    public Button RemoveHome;
    void Start()
    {
        RemoveHome.onClick.AddListener(() => { LoadSceneManager.Instance.LoadSceneHome(); });
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
}
