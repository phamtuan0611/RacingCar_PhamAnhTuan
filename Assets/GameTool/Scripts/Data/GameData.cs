using System;
using AssetsGame.Scripts;
using GameTool;
using UnityEngine;

public class GameData : SingletonMonoBehaviour<GameData>
{
    public GameDataSave Data;

    [Header("RESOURCE")] public CarSource carSource;
    public SpinResource SpinResource;
    [Header("Scene Flow")] public int numberOfPlayers;
    public bool isPlayWithBot;
    public int levelSelect;
    public string gameName;


    protected override void Awake()
    {
        base.Awake();
        Data = new GameDataSave();
        LoadAllData();
    }
    
    #region LOAD DATA
    public void LoadAllData()
    {
        GameDataControl.LoadAllData();
    }
    #endregion LOAD DATA
    
    #region CLEAR DATA
    public void ClearAllData()
    {
        Data = new GameDataSave();
        GameDataControl.SaveAllData();
    }
    #endregion CLEAR DATA

    #region SAVE DATA
    public void SaveAllData()
    {
        GameDataControl.SaveAllData();
    }

    public void SaveData<T>(eData filename, T value)
    {
        var save = new SaveUtility<T>();
        save.SaveData(filename, value);
    }

    public void LoadData<T>(eData filename, ref T variable)
    {
        var save = new SaveUtility<T>();
        save.LoadData(filename, ref variable);
    }
    #endregion SAVE DATA

    public int coin
    {
        get => Data.coin;
        set
        {
            Data.coin = value;
            SaveData(eData.coin, Data.coin);
        } 
    }
    public int gem
    {
        get => Data.gem;
        set
        {
            Data.gem = value;
            SaveData(eData.gem, Data.gem);
        } 
    }

    public SerializedDict<string, bool> DictCarBought
    {
        get => Data.DictCarBought;
    } 
}

[Serializable]
public class GameDataSave
{
    public SerializedDict<string, bool> DictCarBought = new SerializedDict<string, bool>();
    
    public int coin;
    public int gem;
}