using Kuhpik;
using UnityEngine;

namespace _Source.Code.Systems
{
    public class EnemyMovementSystem : GameSystem
    {
        public float Speed;
        
        public override void OnUpdate()
        {
            if(game.Player == null ) return;
            
            foreach (var enemy in game.Enemies)
            {
                var direction = (Vector2)(game.Player.transform.position - enemy.transform.position);
                float targetZRotate = Mathf.Atan2(direction.x, direction.y) * Mathf.Rad2Deg;
                Quaternion targetRotation = Quaternion.Euler(0f, 0f, -targetZRotate);
                enemy.transform.rotation = targetRotation;

                if (Vector2.Distance(game.Player.transform.position, enemy.transform.position) < config.StopDistance) return;

                enemy.transform.position = Vector2.Lerp(enemy.transform.position, game.Player.transform.position,
                    Speed * Time.deltaTime);

            }
        }
    }
}