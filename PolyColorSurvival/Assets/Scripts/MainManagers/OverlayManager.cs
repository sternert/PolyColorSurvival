using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.MainManagers
{
    public class OverlayManager : MonoBehaviour
    {
        public Text scoreText;
        public Slider healthSlider;

        public void SetScore(long score)
        {
            scoreText.text = "Score: " + score + " pts";
        }

        public void SetHealth(float health)
        {
            healthSlider.value = health;
        }
    }
}
