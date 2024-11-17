using Kuhpik;
using UnityEngine;
using UnityEngine.iOS;

namespace _Source.Code.Systems
{
    public class MenuSystem : GameSystemWithScreen<MenuScreen>
    {
        public override void OnInit()
        {
            screen.RateButton.onClick.AddListener(() => Device.RequestStoreReview());
            
            screen.ShopButton.onClick.AddListener(()=>Bootstrap.Instance.ChangeGameState(GameStateID.Shop));
            screen.SettingsButton.onClick.AddListener(()=>Bootstrap.Instance.ChangeGameState(GameStateID.Settings));
            screen.StartGameButton.onClick.AddListener(()=>Bootstrap.Instance.ChangeGameState(GameStateID.Game));
        }

        public override void OnUpdate()
        {
            screen.CoinsText.SetText($"COINS: {player.Coins}");
        }
    }
}