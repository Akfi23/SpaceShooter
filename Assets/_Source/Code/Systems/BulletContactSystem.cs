using _Source.Code.Components;
using _Source.Code.Events;
using DG.Tweening;
using Kuhpik;
using Supyrb;
using UnityEngine;

namespace _Source.Code.Systems
{
    public class BulletContactSystem : GameSystem
    {
        public GameObject CoinPrefab;
        public float CoinsSpawnRadius;
        
        
        public override void OnInit()
        {
            Signals.Get<OnTrigger2DEnterSignal>().AddListener(OnBulletContact);
        }
        
        public override void OnStateExit()
        {
            game.CoinsPerRound = 0;
        }

        private void OnBulletContact(Transform transform,Transform other)
        {
            if(!transform.TryGetComponent(out ShipComponent ship)) return;
            if(!other.TryGetComponent(out BulletComponent bullet)) return;

            ship.CurrentHealth--;
            
            Destroy(other.gameObject);

            if (!DOTween.IsTweening(ship.Image))
            {
                ship.Image.DOColor(Color.red, 0.1f).SetLoops(2, LoopType.Yoyo);
            }
            
            if(ship.CurrentHealth>0) return;

            if (ship.TryGetComponent(out CoinSpawnerComponent coinSpawner))
            {
                for (int i = 0; i < Random.Range(1,3); i++)
                {
                    SpawnCoins(transform.position);
                }

                game.ScorePerRound++;

                game.Enemies.Remove(ship);
            }
            
            Destroy(transform.gameObject);  
        }

        private void SpawnCoins(Vector2 spawnPivot)
        {
            float angle = Random.Range(0f, Mathf.PI * 2);

            float x = Mathf.Cos(angle) * CoinsSpawnRadius;
            float y = Mathf.Sin(angle) * CoinsSpawnRadius;

            Vector2 spawnPosition = new Vector2(x, y);
            spawnPosition += spawnPivot;
            
            Instantiate(CoinPrefab, spawnPosition, Quaternion.identity);
        }
    }
}
