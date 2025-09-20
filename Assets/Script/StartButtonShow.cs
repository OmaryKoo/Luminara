using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class StartButtonShow : MonoBehaviour
{
    private TextMeshProUGUI tmpText;
    public float fadeSpeed = 1f; // 깜빡이는 속도 조절

    void Start()
    {
        tmpText = GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        if (tmpText != null)
        {
            // 알파값을 시간에 따라 PingPong (0~1 사이 반복)
            float alpha = Mathf.PingPong(Time.time * fadeSpeed, 1f);

            // 기존 색 가져와서 알파만 변경
            Color c = tmpText.color;
            c.a = alpha;

            tmpText.color = c;
        }
    }
}
