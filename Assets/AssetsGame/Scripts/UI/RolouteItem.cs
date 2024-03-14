using System;
using System.Collections;
using System.Collections.Generic;
using AssetsGame.Scripts;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public class RolouteItem : MonoBehaviour
{
    public GameObject model;
    public Image imgIcon;
    public TextMeshProUGUI valueText;

    public void SetData(Reward reward )
    {
        switch (reward.itemSpin.itemType)
        {
            case ItemType.Diamond:
            {
                /*imgIcon.sprite = GameData.Instance*/
                break;
            }
            case ItemType.Gold:
            {
                /*imgIcon.sprite = GameData.Instance*/
                break;
            }
            case ItemType.Car:
            {
                /*model = */
                break;
            }
        }
    }
    /*public void SetData(ItemSpin itemSpin)
    {
        model = itemSpin.item;
        imgIcon.sprite = itemSpin.Sprite;
        valueText.text = itemSpin.value.ToString();
    }*/
}


