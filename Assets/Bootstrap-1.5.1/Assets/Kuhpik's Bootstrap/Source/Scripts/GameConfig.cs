using System;
using UnityEngine;
using NaughtyAttributes;

namespace Kuhpik
{
    [CreateAssetMenu(menuName = "Config/GameConfig")]
    public sealed class GameConfig : ScriptableObject
    {
        // Example
        // [SerializeField] [BoxGroup("Moving")] private float moveSpeed;
        // public float MoveSpeed => moveSpeed;

        public float StopDistance;
        
        
        public ShopItemData[] ShopItemDatas;

    }
    
        [Serializable]
        public class ShopItemData
        {
            public Sprite Icon;
            public int Energy;
            public int Damage;
            public int Price;
            public int SkinIndex;
        }
}
