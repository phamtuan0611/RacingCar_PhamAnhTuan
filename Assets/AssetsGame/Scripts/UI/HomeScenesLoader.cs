using System;
using System.Collections;
using System.Collections.Generic;
using GameTool;
using UnityEngine;

public class HomeScenesLoader : MonoBehaviour
{
    private void Awake()
    {
        CanvasManager.Instance.Push(eUIName.HomeMenu);
    }
}
