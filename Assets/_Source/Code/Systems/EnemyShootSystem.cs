using Kuhpik;
using UnityEngine;

namespace _Source.Code.Systems
{
    public class EnemyShootSystem : GameSystem
    {
        public GameObject bulletPrefab;

        public override void OnUpdate()
        {
            foreach (var enemy in game.Enemies)
            {
                if (Vector2.Distance(game.Player.transform.position, enemy.transform.position) > config.StopDistance)
                {
                    enemy.ShootTimer = enemy.ShootDelay;
                }
                else
                {
                    enemy.ShootTimer -= Time.deltaTime;
                    
                    if(enemy.ShootTimer>0) continue;

                    foreach (var point in enemy.ShootPoints)
                    {
                        Instantiate(bulletPrefab, point.position, enemy.transform.rotation);
                    }
                    
                    enemy.ShootTimer = enemy.ShootDelay;

                }
            }
        }
    }
}