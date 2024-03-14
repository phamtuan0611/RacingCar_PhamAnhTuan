using System.Collections;
using System.Collections.Generic;
using GameTool;
using UnityEngine;
using UnityEngine.UI;

public class Roulette : BaseUI
{
    
    public Button spin;
    private float spinTime = 4f;
    private float currentTime;
    public Canvas wheel;
    [SerializeField] protected List<RolouteItem> listRolouteItem = new List<RolouteItem>();
    private float angleOfGift;
    private float circle = 360.0f;
    public AnimationCurve curve;

    void Start()
    {
        setDataForListRolouteItem();
        angleOfGift = circle / listRolouteItem.Count;
        spin.onClick.AddListener(() => { spinAround(); });
    }

    void setDataForListRolouteItem()
    {
        /*for (int i = 0; i < listRolouteItem.Count; i++)
        {
            listRolouteItem[i].SetData(GameData.Instance.SpinResource.ListItemSpins[i]);
        }*/
    }
    
    void spinAround()
    {
        StartCoroutine(RotationWheel());
    }

    IEnumerator RotationWheel()
    {
        float startAngle = transform.eulerAngles.z;
        currentTime = 0;
        int indexGiftRandom = Random.Range(1, listRolouteItem.Count);
        float angleWant = (7.0f * circle) + angleOfGift * indexGiftRandom;
        int i = 0;
        while (currentTime < spinTime)
        {
            i++;
            yield return new WaitForEndOfFrame();
            currentTime += Time.deltaTime;
            float angleCurrent = angleWant * curve.Evaluate(currentTime / spinTime);
            wheel.transform.eulerAngles = new Vector3(0, 0, angleCurrent + startAngle );
        }

    }

}
