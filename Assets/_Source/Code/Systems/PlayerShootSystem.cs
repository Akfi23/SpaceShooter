using Kuhpik;
using UnityEngine;

namespace _Source.Code.Systems
{
    public class PlayerShootSystem : GameSystemWithScreen<GameScreen>
    {
        public GameObject bulletPrefab;
        
        public override void OnInit()
        {
            screen.ShootButton.onClick.AddListener(() =>
            {
                Shoot();
            });
        }

        private void Shoot()
        {
            if(game.Player == null ) return;
            
            if(game.Player.ShootTimer>0) return;

            foreach (var shootPoint in game.Player.ShootPoints)
            {
                Instantiate(bulletPrefab, shootPoint.position, game.Player.transform.rotation);
            }
            

            game.Player.ShootTimer = game.Player.ShootDelay;
        }
    }
}