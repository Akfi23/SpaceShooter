using _Source.Code.Components;
using _Source.Code.Events;
using Kuhpik;
using Supyrb;
using UnityEngine;

namespace _Source.Code.Systems
{
    public class CoinsCollectSystem : GameSystem
    {
        public override void OnInit()
        {
            Signals.Get<OnTrigger2DEnterSignal>().AddListener(OnCoinContact);
        }

        public override void OnStateExit()
        {
            game.CoinsPerRound = 0;
        }

        private void OnCoinContact(Transform transform,Transform other)
        {
            if(!transform.TryGetComponent(out ShipComponent ship)) return;
            if(!other.TryGetComponent(out CoinComponent bullet)) return;
            
            Destroy(other.gameObject);

            player.Coins++;
            game.CoinsPerRound++;
        }
    }
}
