using UnityEngine;

public class LightOrb : MonoBehaviour
{
     private void OnTriggerEnter2D(Collider2D collision)
    {
        LightGrower grower = collision.GetComponent<LightGrower>();
        if (grower != null)
        {
            grower.AbsorbLight();  // 플레이어의 광채 강화
            Destroy(gameObject);  // 빛 오브젝트 제거
        }
    }
}
