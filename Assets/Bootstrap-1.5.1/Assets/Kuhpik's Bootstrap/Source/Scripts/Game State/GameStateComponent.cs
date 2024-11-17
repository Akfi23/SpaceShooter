using NaughtyAttributes;
using System.Collections.Generic;
using System.Linq;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Kuhpik
{
    public class GameStateComponent : MonoBehaviour
    {
        [EnumPaging]
        [SerializeField] GameStateID id;
        [SerializeField] bool useAdditionalStates;
        [EnumPaging]
        [SerializeField] [ReorderableList] [NaughtyAttributes.ShowIf("useAdditionalStates")] GameStateID[] additionalStatesInTheBegining;
        [EnumPaging]
        [SerializeField] [ReorderableList] [NaughtyAttributes.ShowIf("useAdditionalStates")] GameStateID[] additionalStatesInTheEnd;

        [Header("DEBUG")]
        [SerializeField, NaughtyAttributes.ReadOnly] List<string> systemNames;

        GameState state;

        public GameStateID ID => id;
        public bool UseAdditionalStates => useAdditionalStates;
        public GameStateID[] AdditionalStatesInTheBegining => additionalStatesInTheBegining;
        public GameStateID[] AdditionalStatesInTheEnd => additionalStatesInTheEnd;

        public GameState CreateState()
        {
            var systems = new List<IGameSystem>();
            GetSystemsRecursively(systems, transform);
            state = new GameState(id, systems);
            DisplaySystemsInInspector(systems);
            return state;
        }

        public GameState GetState()
        {
            if (state == null)
            {
                CreateState();
            }

            return state;
        }

        void GetSystemsRecursively(List<IGameSystem> systems, Transform target)
        {
            if (!target.gameObject.activeSelf) return;

            if (target.TryGetComponent<IGameSystem>(out var system))
            {
                systems.Add(system);
            }

            for (int i = 0; i < target.childCount; i++)
            {
                var index = i;
                GetSystemsRecursively(systems, target.GetChild(index));
            }
        }

        void DisplaySystemsInInspector(List<IGameSystem> systems)
        {
            systemNames = systems.Select(x => x.GetType().Name).ToList();
        }
    }
}