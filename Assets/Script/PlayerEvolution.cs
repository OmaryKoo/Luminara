using UnityEngine;

public class PlayerEvolution : MonoBehaviour
{
     // 현재 진화 단계를 저장하는 변수
    public EvolutionStage currentStage = EvolutionStage.Egg;

    // 각 진화 단계에 해당하는 오브젝트 (Hierarchy에 미리 배치)
    public GameObject eggObject;
    public GameObject chickObject;
    public GameObject chickenObject;

    // 빛 오브젝트를 먹은 개수
    private int lightOrbsCollected = 0;

    // 진화 조건: 몇 개의 빛을 먹으면 다음 단계로 진화할지 설정
    public int evolveThreshold = 30;

    void Start()
    {
        // 초기화: 오브젝트 활성화/비활성화 설정
        SetStage(currentStage);
    }

    /// <summary>
    /// 외부에서 이 메서드를 호출하면 빛을 1개 먹은 것으로 처리되고 진화 조건검사
    /// </summary>
    public void CollectLightOrb()
    {
        lightOrbsCollected++;

        // 현재 상태가 Egg 또는 Chick일 때만 진화 조건 검사
        if (lightOrbsCollected >= evolveThreshold)
        {
            lightOrbsCollected = 0; // 다음 진화 단계로 넘어가면 카운트 초기화

            if (currentStage == EvolutionStage.Egg)
                SetStage(EvolutionStage.Chick);
            else if (currentStage == EvolutionStage.Chick)
                SetStage(EvolutionStage.Chicken);
        }
    }

    /// <summary>
    /// 현재 진화 단계를 설정하고, 다른 단계는 모두 비활성화
    /// </summary>
    /// <param name="newStage">전환할 진화 단계</param>
    private void SetStage(EvolutionStage newStage)
    {
        currentStage = newStage;

        // 모든 오브젝트 비활성화 후, 해당 오브젝트만 활성화
        eggObject.SetActive(newStage == EvolutionStage.Egg);
        chickObject.SetActive(newStage == EvolutionStage.Chick);
        chickenObject.SetActive(newStage == EvolutionStage.Chicken);
    }
}
