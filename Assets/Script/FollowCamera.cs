using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public Transform playerTarget;
    public Vector3 offset = new Vector3(0f, 0f, -10f);
    public float smoothSpeed = 5f;

    void LateUpdate()
    {
        if (playerTarget = null) return;

        Vector3 desiredPosition = playerTarget.position + offset;
         transform.position = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);
    }

    public void SetTarget(Transform newTarget)
    {
        playerTarget = newTarget;
    }
}
