using UnityEngine;
using UnityEngine.UI;

public class IntroPopupController : MonoBehaviour
{
    
    [Header("Root")]
    public GameObject panelRoot;       // IntroductionPanel
    public CanvasGroup panelCanvasGroup; // 선택사항(있으면 페이드)

    [Header("Tabs (optional style)")]
    public Button aboutBtn;
    public Button howToBtn;
    public Color tabSelected = new Color(1f, 1f, 1f, 1f);
    public Color tabNormal   = new Color(1f, 1f, 1f, 0.5f);

    [Header("Images")]
    public GameObject aboutImage;      // 작품소개 이미지 오브젝트
    public GameObject howToImage;      // 플레이 안내 이미지 오브젝트

    void Awake()
    {
        if (panelRoot != null) panelRoot.SetActive(false);
    }

    // Introduction 버튼에 연결
    public void Open()
    {
        panelRoot.SetActive(true);
        panelRoot.transform.SetAsLastSibling(); // 항상 맨 위

        // 혹시 상위에 Canvas가 있다면 Raycast 우선순위도 확보
    Canvas popupCanvas = panelRoot.GetComponent<Canvas>();
    if (popupCanvas != null)
    {
        popupCanvas.overrideSorting = true;
        popupCanvas.sortingOrder = 500; // 필요 시 높게 조절
    }

        if (panelCanvasGroup != null)
        {
            StopAllCoroutines();
            StartCoroutine(Fade(panelCanvasGroup, 0f, 1f, 0.2f));
        }

        ShowAbout(); // 기본: 작품소개
    }

    // 닫기(X 버튼) 연결
    public void Close()
    {
        if (panelCanvasGroup != null)
        {
            StopAllCoroutines();
            StartCoroutine(Fade(panelCanvasGroup, 1f, 0f, 0.15f, () =>
            {
                panelRoot.SetActive(false);
            }));
        }
        else
        {
            panelRoot.SetActive(false);
        }
    }

    // ‘작품소개’ 버튼 연결
    public void ShowAbout()
    {
        aboutImage.SetActive(true);
        howToImage.SetActive(false);
        SetTabVisual(true);
    }

    // ‘플레이 안내’ 버튼 연결
    public void ShowHowTo()
    {
        aboutImage.SetActive(false);
        howToImage.SetActive(true);
        SetTabVisual(false);
    }

    private void SetTabVisual(bool aboutSelected)
    {
        if (aboutBtn != null)
        {
            var img = aboutBtn.GetComponent<Image>();
            if (img) img.color = aboutSelected ? tabSelected : tabNormal;

            var txt = aboutBtn.GetComponentInChildren<Text>();
            if (txt) txt.color = aboutSelected ? tabSelected : tabNormal;
        }

        if (howToBtn != null)
        {
            var img = howToBtn.GetComponent<Image>();
            if (img) img.color = aboutSelected ? tabNormal : tabSelected;

            var txt = howToBtn.GetComponentInChildren<Text>();
            if (txt) txt.color = aboutSelected ? tabNormal : tabSelected;
        }
    }

    private System.Collections.IEnumerator Fade(CanvasGroup cg, float from, float to, float dur, System.Action onDone = null)
    {
        cg.alpha = from; cg.blocksRaycasts = true; cg.interactable = true;
        float t = 0f;
        while (t < dur)
        {
            t += Time.deltaTime;
            cg.alpha = Mathf.Lerp(from, to, t / dur);
            yield return null;
        }
        if (to == 0f) { cg.blocksRaycasts = false; cg.interactable = false; }
        onDone?.Invoke();
    }

    
}