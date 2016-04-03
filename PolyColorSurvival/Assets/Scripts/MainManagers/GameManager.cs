using Assets.Scripts.Enemy;
using Assets.Scripts.Player;
using UnityEngine;

namespace Assets.Scripts.MainManagers
{
    public class GameManager : MonoBehaviour
    {
        public EnemyManager enemyManager;
        public PlayerMovement playerMovement;

        public void PlayerDied()
        {
            playerMovement.gameObject.SetActive(false);
            StateManager.SetPaused();
        }

        public void StartGame()
        {
            playerMovement.gameObject.SetActive(true);
            enemyManager.Restart();
            playerMovement.Restart();
            StateManager.SetActive();
        }

        public void QuitGame()
        {
            Application.Quit();
        }
    }
}
