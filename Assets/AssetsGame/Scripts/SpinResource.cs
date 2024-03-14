using System;
using System.Collections.Generic;
using UnityEngine;

namespace AssetsGame.Scripts
{
    [CreateAssetMenu(fileName = "SpinResource", menuName = "SpinResource", order = 0)]
    
    public class SpinResource : ScriptableObject
    {
        public List<Reward> ListItemSpins;
    }
    
    
    
    [Serializable]
    public class Reward
    {
        public ItemSpin itemSpin = new ItemSpin();
    }
    
    
    
    [Serializable]
    public class ItemSpin
    {
        public int value;
        public ItemType itemType;
    }
    
    
    
    public enum ItemType
    {
        Gold,
        Diamond ,
        Car ,
    }
}