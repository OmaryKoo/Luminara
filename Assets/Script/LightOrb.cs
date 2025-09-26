using UnityEngine;

public class LightOrb : MonoBehaviour
{
    [Header("Light Info")]
    [TextArea]
    public string lightMessage; //빛 대표메세지

    [Header("Movement Settings")]
    public BoxCollider2D moveArea; // order에 붙어 있어야 함
    public float moveSpeed = 2f;
    public float waitTime = 1.5f;

    //[Header("Rotation Settings")]
    //public float rotateSpeed = 90f; // 초당 회전 속도 (양수: 시계방향, 음수: 반시계방향)

    private Vector3 targetPosition;
    private float waitTimer = 0f;

    private void Start()
    {
        PickNewTarget();
        waitTimer = waitTime;
    }

    private void Update()
    {
        // 목표 지점으로 이동
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);

        // 목표에 거의 도달했으면 대기 시작
        if (Vector3.Distance(transform.position, targetPosition) < 0.05f)
        {
            waitTimer -= Time.deltaTime;

            if (waitTimer <= 0f)
            {
                PickNewTarget();
                waitTimer = waitTime;
            }
        }
         //transform.Rotate(Vector3.forward * rotateSpeed * Time.deltaTime);
    }

    private void PickNewTarget()
    {
        if (moveArea == null)
        {
            Debug.LogWarning("moveArea가 설정되지 않았습니다.");
            return;
        }

        Bounds bounds = moveArea.bounds;

        float randomX = Random.Range(bounds.min.x, bounds.max.x);
        float randomY = Random.Range(bounds.min.y, bounds.max.y);

        targetPosition = new Vector3(randomX, randomY, transform.position.z);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // 빛 오브젝트 수집 → 진화 트리거 시스템
            FindFirstObjectByType<PlayerEvolution>()?.CollectLightOrb();

            // 점수 UI 반영
            FindFirstObjectByType<LightCounter>()?.AddStar();

            //UI 텍스처 메세지 반영
            FindFirstObjectByType<LightUIManager>()?.ShowLight(lightMessage);

            Destroy(gameObject);
        }
    }

}
