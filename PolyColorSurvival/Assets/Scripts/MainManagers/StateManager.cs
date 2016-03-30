using UnityEngine;

namespace Assets.Scripts.MainManagers
{
    public class StateManager : MonoBehaviour
    {
        private static StateManager fetch;

        private GameState currentState = GameState.Active;

        public static GameState CurrentState
        {
            get { return fetch ? fetch.currentState : GameState.Undefined; }
            set {
                if (fetch)
                {
                    fetch.currentState = value;
                }
            }
        }

        void Awake()
        {
            fetch = this;
        }
    }

    public enum GameState
    {
        Undefined,
        Paused,
        Active
    }
}
