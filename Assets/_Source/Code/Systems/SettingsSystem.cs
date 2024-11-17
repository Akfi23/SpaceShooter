using _Source.Code.UI;
using Kuhpik;
using UnityEngine;
using UnityEngine.iOS;

namespace _Source.Code.Systems
{
    public class SettingsSystem : GameSystemWithScreen<SettingsScreen>
    {
        private AudioListener _listener;
        private bool _isVibro = true;
        
        public override void OnInit()
        {
            _listener = FindObjectOfType<AudioListener>();
            
            screen.BackButton.onClick.AddListener(()=>Bootstrap.Instance.ChangeGameState(GameStateID.Menu));
            screen.SoundButton.onClick.AddListener(()=>
            {
                _listener.enabled = !_listener.enabled;

                screen.SoundToggleImage.sprite = _listener.enabled ? screen.ToggleOn : screen.ToggleOff;
            });
            
            screen.VibroButton.onClick.AddListener(()=>
            {
                _isVibro = !_isVibro;

                screen.VibroToggleImage.sprite = _isVibro ? screen.ToggleOn : screen.ToggleOff;
            });
            
            screen.RateButton.onClick.AddListener(()=>Device.RequestStoreReview());
            
            screen.ClearDataButton.onClick.AddListener(()=>PlayerPrefs.DeleteAll());
        }
    }
}