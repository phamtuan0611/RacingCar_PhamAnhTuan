using System;
using System.Collections;
using System.Collections.Generic;
using GameTool;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Shopping : BaseUI
{
    public Button closeBtn;
    public GameObject currentCar;
    public GameObject carPos;
    private int i = 0;
    [SerializeField] private Button onBuy;

    public TextMeshProUGUI costCar;

    // Start is called before the first frame update
    private void Awake()
    {
        closeBtn.onClick.AddListener(Pop);

        onBuy.onClick.AddListener(OnBuy);
    }

    public override void Init(params object[] args)
    {
        base.Init(args);
        i = Shop.Instance.index; //Shop sau khi ke thua Singleton<Shop> se giong nhu GameData, co the truy xuat vao bien index cua Shop
        SetData();
    }

    public void SetData()
    {
        var source = GameData.Instance.carSource.listCar;
        currentCar = Instantiate(GameData.Instance.carSource.listCar[i].Car, carPos.transform);
        currentCar.transform.position = carPos.transform.position;
        currentCar.transform.localScale = Vector3.one * 150;
        costCar.text = source[i].costCar.ToString();
    }

    public void OnBuy()
    {
        var Id = GameData.Instance.carSource.listCar[i].Id;
        if (!GameData.Instance.DictCarBought.ContainsKey(Id.ToString())) //kiem tra xem trong DictCarBought da co xem co id xe can mua chua
        {
            GameData.Instance.DictCarBought.Add(Id.ToString(), true); //neu true thi them id car vao Dict va true(da ban)
        }
        else
        {
            GameData.Instance.DictCarBought[Id.ToString()] = true;
        }

        GameData.Instance.SaveData(eData.DictCarBought, GameData.Instance.DictCarBought);
    }
}