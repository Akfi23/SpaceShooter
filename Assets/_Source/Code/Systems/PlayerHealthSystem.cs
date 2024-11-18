using Kuhpik;

namespace _Source.Code.Systems
{
    public class PlayerHealthSystem : GameSystemWithScreen<GameScreen>
    {
        public override void OnUpdate()
        {
            if(game.Player==null) return;
            
            int fullHearts = game.Player.CurrentHealth / 2;
            bool hasHalfHeart = game.Player.CurrentHealth % 2 == 1;

            for (int i = 0; i < screen.Hearts.Length; i++)
            {
                if (i < fullHearts)
                {
                    screen.Hearts[i].fillAmount = 1;
                }
                else if (i == fullHearts && hasHalfHeart)
                {
                    screen.Hearts[i].fillAmount = 0.5f;
                }
                else
                {
                    screen.Hearts[i].fillAmount = 0f;
                }
            }
        }
    }
}