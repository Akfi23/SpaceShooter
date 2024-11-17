using Kuhpik;

namespace _Source.Code.Systems
{
    public class ResultSystem :GameSystemWithScreen<ResultScreen>
    {
        public override void OnInit()
        {
            screen.NextGameButton.onClick.AddListener(()=>Bootstrap.Instance.ChangeGameState(GameStateID.Menu));
        }

        public override void OnStateEnter()
        {
            screen.CoinsText.SetText($"COINS: {game.CoinsPerRound}");
            screen.ScoreText.SetText($"SCORE: {game.ScorePerRound}");
        }
    }
}