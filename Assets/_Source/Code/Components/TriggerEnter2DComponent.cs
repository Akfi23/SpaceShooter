using _Source.Code.Events;
using Supyrb;
using UnityEngine;

namespace _Source.Code.Components
{
    public class TriggerEnter2DComponent : MonoBehaviour
    {
        private OnTrigger2DEnterSignal _signal;
    
        private void Start()
        { 
            _signal = Signals.Get<OnTrigger2DEnterSignal>();
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            _signal.Dispatch(other.transform);
        }
    }
}
