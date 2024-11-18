using System.Linq;
using _Source.Code.Components;
using Kuhpik;
using UnityEngine;

namespace _Source.Code.Systems
{
    public class SetupPlayerShipSystem : GameSystem
    {
        public PlayerShipComponent PlayerShip;
        
        public override void OnStateEnter()
        {
            game.Player = Instantiate(PlayerShip,Vector2.zero,Quaternion.identity);
            game.Player.Image.sprite = config.ShopItemDatas.First(x => x.SkinIndex == player.CurrentSkinIndex).Icon;
        }

        public override void OnStateExit()
        {
            Destroy(game.Player.gameObject);
        }
    }
}