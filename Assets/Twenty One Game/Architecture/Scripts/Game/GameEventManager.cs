using UnityEngine;
using UnityEngine.Events;

namespace Game
{
    public class GameEventManager : MonoBehaviour
    {
        public static GameEventManager Instance;
        [HideInInspector] public UnityEvent OnPlayerWin;
        [HideInInspector] public UnityEvent OnNPCWin;
        [HideInInspector] public UnityEvent OnNPCFInish;
        [HideInInspector] public UnityEvent OnNPCTurn;
        [HideInInspector] public UnityEvent OnDraw;
        // SOUND
        [HideInInspector] public UnityEvent OnCardSound;
        // UI
        [HideInInspector] public UnityEvent OnLoadMenuOpened;
        [HideInInspector] public UnityEvent OnLoadMenuClosed;

        private void Awake()
        {
            if(Instance != null) return;
            Instance = this;
        }

        private void Start()
        {
            OnLoadMenuClosed.Invoke();
        }
    }
}
