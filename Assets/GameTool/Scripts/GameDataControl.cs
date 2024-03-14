namespace GameTool
{
    public static class GameDataControl
    {
        public static void SaveAllData()
        {
            GameData.Instance.SaveData(eData.DictCarBought, GameData.Instance.Data.DictCarBought);
            GameData.Instance.SaveData(eData.coin, GameData.Instance.Data.coin);
            GameData.Instance.SaveData(eData.gem, GameData.Instance.Data.gem);
        }

        public static void LoadAllData()
        {
            GameData.Instance.LoadData(eData.DictCarBought, ref GameData.Instance.Data.DictCarBought);
            GameData.Instance.LoadData(eData.coin, ref GameData.Instance.Data.coin);
            GameData.Instance.LoadData(eData.gem, ref GameData.Instance.Data.gem);
        }
    }
}
