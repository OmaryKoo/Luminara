using UnityEngine;
// 플레이어의 진화 단계를 정의하는 열거형 enum
// 이후 다른 스크립트에서도 이 enum을 불러와 진화 상태를 쉽게 비교 및 처리가능

public enum EvolutionStage
{
    Egg,
    Chick,
    Chicken,
    Phoenix
}
