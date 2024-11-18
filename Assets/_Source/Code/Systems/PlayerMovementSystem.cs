using System;
using Kuhpik;
using UnityEngine;

namespace _Source.Code.Systems
{
    public class PlayerMovementSystem : GameSystemWithScreen<GameScreen>
    {
        public float Speed;
        public float RotationSpeed;
        private float zRotation;
        public override void OnUpdate()
        {
            if(game.Player == null ) return;

            game.Player.transform.Translate(Vector2.up * (Speed * Time.deltaTime * screen.Joystick.Direction.sqrMagnitude));

            if (screen.Joystick.Direction.sqrMagnitude > 0)
            {
                float targetZRotate = Mathf.Atan2(screen.Joystick.Direction.x, screen.Joystick.Direction.y) * Mathf.Rad2Deg;
                Quaternion targetRotation = Quaternion.Euler(0f, 0f, -targetZRotate);
                game.Player.transform.rotation = Quaternion.Slerp(game.Player.transform.rotation, targetRotation, RotationSpeed * Time.deltaTime);
            }
        }
    }
}