using UnityEngine;
using TMPro;

public class ResultSceneScoreDisplay : MonoBehaviour
{
    public TextMeshProUGUI scoreText;

    void Start()
    {
        if (ScoreManager.Instance != null)
        {
            scoreText.text = ScoreManager.Instance.GetScore().ToString();
        }
    }
}
