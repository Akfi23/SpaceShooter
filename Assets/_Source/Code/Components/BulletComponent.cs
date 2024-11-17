using System;
using UnityEngine;

namespace _Source.Code.Components
{
    public class BulletComponent : MonoBehaviour
    {
        public float Speed;

        public void Update()
        {
            transform.Translate(Vector3.up * Speed * Time.deltaTime);
        }
    }
}
