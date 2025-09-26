using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LightUIManager : MonoBehaviour
{
    public Text lightTextUI;

    public float showDuration = 1f;
    public float fadeDuration = 1f;

    private Coroutine currentRoutine;

    void Start()
    {
        lightTextUI.color = new Color(1, 1, 1, 0);
    }

    public void ShowLight(string message)
    {
        if (currentRoutine != null)
            StopCoroutine(currentRoutine);

        currentRoutine = StartCoroutine(ShowLightRoutine(message));
    }

    private IEnumerator ShowLightRoutine(string message)
    {

        lightTextUI.text = message;
        lightTextUI.color = new Color(0.996f, 0.996f, 0.835f, 1f);

        yield return new WaitForSeconds(showDuration);

        float t = 0;
        while (t < fadeDuration)
        {
            t += Time.deltaTime;
            float a = Mathf.Lerp(1, 0, t / fadeDuration);

            lightTextUI.color = new Color(0.996f, 0.996f, 0.835f, a);

            yield return null;
        }

        currentRoutine = null;
    }
}
