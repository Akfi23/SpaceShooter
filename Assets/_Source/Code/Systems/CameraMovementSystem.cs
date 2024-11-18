using Kuhpik;
using UnityEngine;

namespace _Source.Code.Systems
{
    public class CameraMovementSystem : GameSystem
    {
        private Camera _camera;
        public float Speed;

        public override void OnInit()
        {
            _camera = Camera.main;
        }

        public override void OnStateEnter()
        {
            _camera.transform.position = Vector2.zero;
        }

        public override void OnLateUpdate()
        {
            if(game.Player == null ) return;
            
            _camera.transform.position = Vector2.Lerp(_camera.transform.position,game.Player.transform.position,Time.deltaTime * Speed);
        }
    }
}