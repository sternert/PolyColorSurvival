using UnityEngine;

namespace Assets.Scripts.MainManagers
{
    public class GameManager : MonoBehaviour {

        private static GameManager fetch;

        void Awake()
        {
            fetch = this;
        }

        public static void PlayerDied()
        {
            StateManager.CurrentState = GameState.Paused;
        }
    }
}
