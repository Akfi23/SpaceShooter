using Kuhpik;

namespace _Source.Code.Systems
{
    public class GameUISystem : GameSystemWithScreen<GameScreen>
    {
        public override void OnInit()
        {
            screen.BackButton.onClick.AddListener(()=>Bootstrap.Instance.ChangeGameState(GameStateID.Menu));
            screen.InfoButton.onClick.AddListener(()=>{});
        }

        public override void OnUpdate()
        {
            screen.ScoreText.SetText($"SCORE: {game.ScorePerRound}");
        }
    }
}