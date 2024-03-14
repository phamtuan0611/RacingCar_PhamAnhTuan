using System;
using System.Collections;
using System.Collections.Generic;
using GameTool;
using UnityEngine;
using UnityEngine.UI;

public class RankingMenu : BaseUI
{
    public Button buttonBack;

    private void Awake()
    {
        buttonBack.onClick.AddListener(Pop);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
