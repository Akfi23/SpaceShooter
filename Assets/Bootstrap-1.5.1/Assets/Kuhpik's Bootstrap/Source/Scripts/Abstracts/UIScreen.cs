using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Kuhpik
{
    public class UIScreen : MonoBehaviour, IUIScreen
    {
        [SerializeField] [NaughtyAttributes.BoxGroup("Settings")] bool shouldOpenWithState;
        [SerializeField] [NaughtyAttributes.BoxGroup("Settings")] bool getScreenFromChild = true;
        [SerializeField] [NaughtyAttributes.BoxGroup("Settings")] [NaughtyAttributes.HideIf("getScreenFromChild")] GameObject screen;
        [EnumPaging]
        [SerializeField] [NaughtyAttributes.BoxGroup("Settings")] [NaughtyAttributes.ShowIf("shouldOpenWithState")] GameStateID[] statesToOpenWith;

        //You will get the idea once you use it
        [SerializeField] [NaughtyAttributes.BoxGroup("Elements")] bool hideElementsOnOpen;
        [SerializeField] [NaughtyAttributes.BoxGroup("Elements")] bool showElementsOnHide;

        [SerializeField] [NaughtyAttributes.BoxGroup("Elements")] [NaughtyAttributes.ShowIf("hideElementsOnOpen")] GameObject[] elementsToHideOnOpen;
        [SerializeField] [NaughtyAttributes.BoxGroup("Elements")] [NaughtyAttributes.ShowIf("showElementsOnHide")] GameObject[] elementsToShowOnHide;

        HashSet<GameStateID> statesMap;

        void Awake()
        {
            screen = getScreenFromChild ? transform.GetChild(0).gameObject : screen;
            statesMap = new HashSet<GameStateID>(statesToOpenWith);
        }

        public virtual void Open()
        {
            foreach (var element in elementsToHideOnOpen)
            {
                element.SetActive(false);
            }

            screen.SetActive(true);
        }

        public virtual void Close()
        {
            foreach (var element in elementsToShowOnHide)
            {
                element.SetActive(true);
            }

            screen.SetActive(false);
        }

        /// <summary>
        /// Subscribe is called on Awake()
        /// </summary>
        public virtual void Subscribe()
        {
        }

        internal void TryOpenWithState(GameStateID id)
        {
            if (shouldOpenWithState && statesMap.Contains(id))
            {
                Open();
            }
        }
    }
}