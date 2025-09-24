using UnityEngine;

public class UIFollower : MonoBehaviour
{
    public PlayerEvolution playerEvolution; // 진화 관리 스크립트 참조
    public Vector3 offset = new Vector3(0.3f, -0.5f, 0f); // UI 위치 오프셋
    public bool faceCamera = true; // UI가 카메라를 바라보게 할지

    private Transform uiTransform;

    void Start()
    {
        uiTransform = transform;
    }

    void LateUpdate()
    {
        if (playerEvolution == null) return;

        Transform target = playerEvolution.GetCurrentActiveTransform();

        if (target != null)
        {
            uiTransform.position = target.position + offset;

            if (faceCamera && Camera.main != null)
            {
                uiTransform.forward = Camera.main.transform.forward;
            }
        }
    }
}
