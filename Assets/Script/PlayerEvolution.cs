using Unity.VisualScripting;
using UnityEngine;

public class PlayerEvolution : MonoBehaviour
{
    // 현재 진화 단계를 저장하는 변수
    public EvolutionStage currentStage = EvolutionStage.Egg;

    // 각 진화 단계에 해당하는 오브젝트 (Hierarchy에 미리 배치)
    public GameObject eggObject;
    public GameObject chickObject;
    public GameObject chickenObject;
    public GameObject phoenixObject;
    public ParticleSystem glowEffect;

    public float glowBaseScale = 0.01f;
    public int scaleIncreaseStep = 10; // 10개마다 scale 증가
    public float scaleIncrement = 0.01f;


    // 빛 오브젝트를 먹은 개수
    private int lightOrbsCollected = 0;
    private int totalLightOrbsCollected = 0; // 누적 수

    // 진화 조건: 몇 개의 빛을 먹으면 다음 단계로 진화할지 설정
    public int evolveThreshold = 30;

    void Start()
    {
        // 초기화: 오브젝트 활성화/비활성화 설정
        SetStage(currentStage);
    }

    void Update()
{
    if (glowEffect != null)
    {
        Transform targetTransform = GetActiveStageTransform();
        glowEffect.transform.position = targetTransform.position;
    }
}


    /// <summary>
    /// 외부에서 이 메서드를 호출하면 빛을 1개 먹은 것으로 처리되고 진화 조건검사
    /// </summary>
    public void CollectLightOrb()
    {
        lightOrbsCollected++;
        totalLightOrbsCollected++; // 누적 개수 증가

        UpdateParticleScale();

         while (lightOrbsCollected >= evolveThreshold)
    {
        lightOrbsCollected -= evolveThreshold;

        if (currentStage == EvolutionStage.Egg)
            SetStage(EvolutionStage.Chick);
        else if (currentStage == EvolutionStage.Chick)
            SetStage(EvolutionStage.Chicken);
        else if (currentStage == EvolutionStage.Chicken)
            SetStage(EvolutionStage.Phoenix);
        else
            break; // Phoenix이면 더 이상 진화하지 않음
    }
}


    private void UpdateParticleScale()
{
    if (glowEffect != null)
    {
        int multiplier = totalLightOrbsCollected / scaleIncreaseStep;
        float newScale = glowBaseScale + (multiplier * scaleIncrement);

        glowEffect.transform.localScale = Vector3.one * newScale;
    }
}

    /// <summary>
    /// 현재 진화 단계를 설정하고, 다른 단계는 모두 비활성화
    private void SetStage(EvolutionStage newStage)
    {
        // 이전 활성 오브젝트의 위치 저장
        Vector3 currentPosition = Vector3.zero;

        if (eggObject.activeSelf) currentPosition = eggObject.transform.position;
        else if (chickObject.activeSelf) currentPosition = chickObject.transform.position;
        else if (chickenObject.activeSelf) currentPosition = chickenObject.transform.position;
        else if (phoenixObject.activeSelf) currentPosition = phoenixObject.transform.position;

        // 모든 오브젝트 비활성화
        eggObject.SetActive(false);
        chickObject.SetActive(false);
        chickenObject.SetActive(false);
        phoenixObject.SetActive(false);

        // 새로운 오브젝트 활성화 + 위치 이전
        if (newStage == EvolutionStage.Egg)
        {
            eggObject.SetActive(true);
            eggObject.transform.position = currentPosition;
        }
        else if (newStage == EvolutionStage.Chick)
        {
            chickObject.SetActive(true);
            chickObject.transform.position = currentPosition;
        }
        else if (newStage == EvolutionStage.Chicken)
        {
            chickenObject.SetActive(true);
            chickenObject.transform.position = currentPosition;
        }
        else if (newStage == EvolutionStage.Phoenix)
        {
            phoenixObject.SetActive(true);
            phoenixObject.transform.position = currentPosition;
        }

        currentStage = newStage;

        if (glowEffect != null)
            {
                 glowEffect.transform.position = GetActiveStageTransform().position;
             }
    }

    private Transform GetActiveStageTransform()
    {
        if (eggObject.activeSelf) return eggObject.transform;
        if (chickObject.activeSelf) return chickObject.transform;
        if (chickenObject.activeSelf) return chickenObject.transform;
        if (phoenixObject.activeSelf) return phoenixObject.transform;
        return transform;
    }

}
