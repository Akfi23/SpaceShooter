using System;
using UnityEngine;
using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using _Source.Code.Components;

namespace Kuhpik
{
    /// <summary>
    /// Used to store game data. Change it the way you want.
    /// </summary>
    [Serializable]
    public class GameData
    {
        // Example (I use public fields for data, but u free to use properties\methods etc)
        // public float LevelProgress;
        // public Enemy[] Enemies;
        public int CoinsPerRound;
        public int ScorePerRound;
        public PlayerShipComponent Player;

        public List<ShipComponent> Enemies = new List<ShipComponent>();
    }
}