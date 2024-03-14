using System;
using System.Collections;
using System.Collections.Generic;
using GameTool;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Shop : SingletonUI<Shop>
{
    public Button backBtn;
    public Button seeMoreBtn;
    public GameObject spawnPos;
    public Button previousBtn;
    public Button nextBtn;
    public GameObject currentCar;
    public int index=0;
    public TextMeshProUGUI nameCarText;
    private void Awake()
    {
        backBtn.onClick.AddListener((Pop));
        SetData();
        previousBtn.onClick.AddListener(OnPreviourClick);
        nextBtn.onClick.AddListener(OnNextClick); //trong ngoac ctrl space de ra goi y
        seeMoreBtn.onClick.AddListener(() =>
        {
           // CanvasManager.Instance.Push(eUIName.Shoppingpopup);
        });
    }

    public void SetData()
    {
        var source = GameData.Instance.carSource.listCar;
        currentCar = Instantiate(GameData.Instance.carSource.listCar[index].Car, spawnPos.transform);
        currentCar.transform.position = spawnPos.transform.position;
        currentCar.transform.localScale = Vector3.one * 150;
        nameCarText.text = source[index].nameCar;
        nameCarText.color = GameData.Instance.carSource.listRank[source[index].colorRank];
    }

    private void OnNextClick()
    {
        Destroy(currentCar);
        if (index == GameData.Instance.carSource.listCar.Count - 1)
        {
            index = 0;
        }
        else
        {
            index++;
        }

        SetData();
    }

    private void OnPreviourClick()
    {
        Destroy(currentCar);
        if (index == 0)
        {
            index = GameData.Instance.carSource.listCar.Count - 1;
        }
        else
        {
            index--;
        }
        SetData();
    }
    
    
}

