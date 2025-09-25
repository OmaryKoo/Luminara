using UnityEngine;
using TMPro;

public class LightCounter : MonoBehaviour
{
    public TextMeshProUGUI starCountText;
    private int starCount = 0;

    public void AddStar()
    {
        starCount++;
        starCountText.text = starCount.ToString();

         if (ScoreManager.Instance != null)
        {
            ScoreManager.Instance.SetScore(starCount);
        }
    }

    public int GetStarCount()
    {
        return starCount;
    }
}
