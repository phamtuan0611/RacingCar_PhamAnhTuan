using System.Collections;
using System.Collections.Generic;
using GameTool;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;
public class LobbyMenu : BaseUI
{
    // Start is called before the first frame update
    public TextMeshProUGUI textCoin;
    public TextMeshProUGUI textGem;

    public Button shopBtn;
    public Button RankingBtn;
    public Button SpinBtn;

    // public GameObject[] backgrounds;
    // public float delay = 4f;
    //
    // private int index = 0;
    public Button settingBtn;

    public Button playBattle; 
    void Start()
    {
        GameData.Instance.coin += 10;
        textCoin.text = GameData.Instance.coin.ToString();
        GameData.Instance.gem += 5;
        textGem.text = GameData.Instance.gem.ToString();
        //StartCoroutine(LoadBackground());
        shopBtn.onClick.AddListener(() => { CanvasManager.Instance.Push(eUIName.AdRemovePopup); });
        settingBtn.onClick.AddListener(() => { CanvasManager.Instance.Push(eUIName.Setting); });
        RankingBtn.onClick.AddListener(() => { CanvasManager.Instance.Push(eUIName.RankingMenu); });
        SpinBtn.onClick.AddListener(() => { CanvasManager.Instance.Push(eUIName.SpinMenu); });
        playBattle.onClick.AddListener(() => { LoadSceneManager.Instance.LoadSceneGame(); });
    }

    // IEnumerator LoadBackground()
    // {
    //     while (true)
    //     {
    //         yield return
    //             new WaitForSeconds(
    //                 delay); // Cho 1 thoi gian duoc cai san roi moi xuat hien, doi load xong. Neu khong co thi no se hien luon
    //         // backgrounds[index].SetActive(false); //Sau khi man hinh loading da load xong thi sẽ làm no an đi 
    //         // // currentIndex = (currentIndex + 1) % backgrounds.Length; //Dam bao chi so luon dung, khong bi sai lech
    //         // index = index + 1; 
    //         backgrounds[index].SetActive(true); //Man hinh phia sau duoc hien thi len
    //     }
    // }

    // Update is called once per frame
    void Update()
    {
    }
}