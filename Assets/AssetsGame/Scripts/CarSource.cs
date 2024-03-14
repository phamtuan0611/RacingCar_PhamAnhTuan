using System;
using System.Collections.Generic;
using UnityEngine;

namespace AssetsGame.Scripts
{
    [CreateAssetMenu(fileName = "CarSource", menuName = "CarSource", order = 0)]
    public class CarSource : ScriptableObject
    {
        public List<CarSourceItem> listCar;
        public List<Color> listRank;
    }

    [Serializable]
    public class CarSourceItem
    {
        public int Id;
        public int costCar;
        public GameObject Car;
        public int colorRank;
        public string nameCar;
    }
}