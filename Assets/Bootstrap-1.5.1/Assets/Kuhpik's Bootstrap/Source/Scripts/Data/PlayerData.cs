using System;
using UnityEngine;
using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;

namespace Kuhpik
{
    /// <summary>
    /// Used to store player's data. Change it the way you want.
    /// </summary>
    [Serializable]
    public class PlayerData
    {
        public int Coins;
        public int Score;
        public int CurrentSkinIndex;
        public int[] BoughtSkinsIndexes=new []{0};
    }
}