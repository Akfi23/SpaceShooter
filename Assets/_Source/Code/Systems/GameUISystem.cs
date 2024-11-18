using Kuhpik;
using UnityEngine;

namespace _Source.Code.Systems
{
    public class GameUISystem : GameSystemWithScreen<GameScreen>
    {
        public override void OnInit()
        {
            screen.BackButton.onClick.AddListener(()=>Bootstrap.Instance.ChangeGameState(GameStateID.Menu));
            
            screen.InfoButton.onClick.AddListener(() =>
            {
                Time.timeScale = 0;
                screen.InfoPanel.SetActive(true);
            });
            
            screen.CloseInfoButton.onClick.AddListener(() =>
            {
                Time.timeScale = 1;
                screen.InfoPanel.SetActive(false);
            });
        }

        public override void OnStateExit()
        {
            Bootstrap.Instance.SaveGame();
        }

        public override void OnUpdate()
        {
            screen.ScoreText.SetText($"SCORE: {game.ScorePerRound}");
        }
    }
}