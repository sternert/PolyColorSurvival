using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.MainManagers
{
    public class MenuManager : MonoBehaviour
    {
        public GameObject lastGameObjects;
        public Text scoreText;

        public void SetLastGame(bool enabled)
        {
            lastGameObjects.SetActive(enabled);
        }

        public void SetScore(long score)
        {
            scoreText.text = score + " pts";
        }

    }
}
