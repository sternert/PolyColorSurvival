using UnityEngine;

namespace Assets.Scripts.MainManagers
{
    public class StateManager : MonoBehaviour
    {
        public GameObject menu;

        private static StateManager fetch;

        private GameState currentState = GameState.Paused;
        private MenuState menuState = MenuState.Start;
        private MenuManager _menuManager;
        private long totalScore = 0;

        public static long TotalScore
        {
            get { return fetch.totalScore; }
        }

        public static GameState CurrentState
        {
            get { return fetch.currentState; }
        }

        public static void AddPoints(long points)
        {
            fetch.totalScore += points;
        }

        public static void SetPaused()
        {
            fetch.currentState = GameState.Paused;
            fetch.menuState = MenuState.Restart;
            fetch.menu.SetActive(true);
            fetch._menuManager.SetScore(fetch.totalScore);
            fetch.totalScore = 0;
            fetch._menuManager.SetLastGame(true);
        }

        public static void SetActive()
        {
            fetch.menu.SetActive(false);
            fetch.menuState = MenuState.Restart;
            fetch.currentState = GameState.Active;
        }

        void Awake()
        {
            fetch = this;
            fetch._menuManager = menu.GetComponent<MenuManager>();
        }

        private enum MenuState
        {
            Start,
            Restart
        }
    }

    public enum GameState
    {
        Undefined,
        Paused,
        Active
    }
}
