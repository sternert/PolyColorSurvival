using UnityEngine;
using UnityEngine.UI;

public class OverlayManager : MonoBehaviour
{

    public Text ScoreText;

    public void SetScore(long score)
    {
        ScoreText.text = "Score: " + score + " pts";
    }
}
