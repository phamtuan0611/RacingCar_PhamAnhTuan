using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using GameTool;
using TMPro;

public class Setting : BaseUI
{
    public Button closeSetting;
    // Start is called before the first frame update
    // void Start()
    // {
    //     closeSetting.onClick.AddListener(() => { CanvasManager.Instance.Push(eUIName.CloseSetting); });
    // }

    // Update is called once per frame
    private void Awake()
    {
        closeSetting.onClick.AddListener((Pop));
    }
}
