using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class TimerController : MonoBehaviour
{
    public float timeRemaining = 100f;
    public TextMeshProUGUI timerText;

    public string resultSceneName = "ResultScene";

    private bool isRunning = true;

    void Update()
    {
        if (isRunning)
        {
            timeRemaining -= Time.deltaTime;

            if (timeRemaining <= 0)
            {
                timeRemaining = 0;
                isRunning = false;
                EndGame();
            }

            UpdateTimerUI();
        }
    }

    void UpdateTimerUI()
    {
        timerText.text = Mathf.CeilToInt(timeRemaining).ToString();
    }

    void EndGame()
    {
        // 플레이어 비활성화
        GameObject player = GameObject.FindWithTag("Player");
        if (player != null)
        {
            player.SetActive(false);
        }

        // 씬 전환
        SceneManager.LoadScene(resultSceneName);
    }
}
