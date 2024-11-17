using _Source.Code.Components;
using Kuhpik;

namespace _Source.Code.Systems
{
    public class LoadingSystem : GameSystem
    {
        public override void OnInit()
        {
            game.Player = FindObjectOfType<PlayerShipComponent>();
        }

        public override void OnStateEnter()
        {
            Bootstrap.Instance.ChangeGameState(GameStateID.Menu);
        }
    }
}
