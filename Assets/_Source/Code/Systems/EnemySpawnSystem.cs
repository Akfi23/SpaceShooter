using System.Collections.Generic;
using Kuhpik;
using UnityEngine;
using Random = UnityEngine.Random;

namespace _Source.Code.Systems
{
    public class EnemySpawnSystem : GameSystem
    {
        public ShipComponent EnemyPrefab;
        public float SpawnRadius;
        public Vector2Int SpawnCountBounds;

        public float SpawnDelay;
        private float _spawnTimer;

        public override void OnStateEnter()
        {
            _spawnTimer = SpawnDelay;
            game.Enemies = new List<ShipComponent>();
        }

        public override void OnStateExit()
        {
            foreach (var enemy in game.Enemies)
            {
                Destroy(enemy.gameObject);
            }

            game.Enemies = null;
        }

        public override void OnUpdate()
        {
            if(game.Player == null ) return;

            _spawnTimer -= Time.deltaTime;
            
            if(_spawnTimer>0) return;

            var count = Random.Range(SpawnCountBounds.x, SpawnCountBounds.y);

            for (int i = 0; i < count; i++)
            {
                float angle = Random.Range(0f, Mathf.PI * 2);

                float x = Mathf.Cos(angle) * SpawnRadius;
                float y = Mathf.Sin(angle) * SpawnRadius;

                Vector2 spawnPosition = new Vector2(x, y);
                spawnPosition += (Vector2)game.Player.transform.position;

                var direction = (Vector2)game.Player.transform.position - spawnPosition;
                float targetZRotate = Mathf.Atan2(direction.x, direction.y) * Mathf.Rad2Deg;
                Quaternion targetRotation = Quaternion.Euler(0f, 0f, -targetZRotate);
                
                game.Enemies.Add(Instantiate(EnemyPrefab, spawnPosition, targetRotation));
            }

            _spawnTimer = SpawnDelay;
        }
    }
}