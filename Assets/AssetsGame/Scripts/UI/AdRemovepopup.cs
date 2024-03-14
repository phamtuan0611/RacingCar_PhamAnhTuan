using System;
using System.Collections;
using System.Collections.Generic;
using GameTool;
using UnityEngine;
using UnityEngine.UI;

public class AdRemovepopup : BaseUI
{
    public Button closeBtn;

    private void Start()
    {
        closeBtn.onClick.AddListener((() =>
        {
            CanvasManager.Instance.Push(eUIName.Shop);
            Pop();
        }));
    }
}
