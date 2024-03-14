using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using DG.Tweening;
using GameTool;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SplPopup : BaseUI
{
    //public Transform loading;

    public Image loadingBar;

    // public bool loadingUp;
    public float waitTime = 3f;
    public Slider slider;

    public TextMeshProUGUI Text;
    // public GameObject[] backgrounds;
    // public float delay = 4f;
    //
    // private int index = 0;

    // Start is called before the first frame update
    void Start()
    {
        loadingBar.DOFillAmount(1, 3).OnComplete(() =>
        {
            LoadSceneManager.Instance.LoadSceneHome();
        });
    }

    // Method to change the value of the slider
    public void ChangeSliderValue(float value)
    {
        slider.value += (value / waitTime * Time.deltaTime);
    }

    // Update is called once per frame

    // IEnumerator LoadBackground()
    // {
    //     while (true)
    //     {
    //         yield return new WaitForSeconds(delay);// Cho 1 thoi gian duoc cai san roi moi xuat hien, doi load xong. Neu khong co thi no se hien luon
    //         backgrounds[index].SetActive(false); //Sau khi man hinh loading da load xong thi sẽ làm no an đi 
    //         // currentIndex = (currentIndex + 1) % backgrounds.Length; //Dam bao chi so luon dung, khong bi sai lech
    //         index = index + 1; 
    //         backgrounds[index].SetActive(true); //Man hinh phia sau duoc hien thi len
    //     }
    // }

    void Update()
    {
        ChangeSliderValue(1.0f);
        Text.text = "Loading..." + (int) (loadingBar.fillAmount * 100f) + "%";
    }
}