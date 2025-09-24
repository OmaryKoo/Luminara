using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float deceleration = 1f;
    public BoxCollider2D moveArea;

    private Vector2 startTouchPos;  // 🔹 터치 시작 위치
    private Vector2 endTouchPos;    // 🔹 터치 종료 or 이동 위치

    private Vector2 currentDirection = Vector2.zero;
    private Vector2 velocity = Vector2.zero;

    private Transform currentPlayer;

    private FollowCamera followCam;

    public void SetSpeed(float newSpeed)
    {
        moveSpeed = newSpeed;
    }

void Start()
{
    followCam = Camera.main.GetComponent<FollowCamera>();
}

    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                startTouchPos = touch.position;
            }
            else if (touch.phase == TouchPhase.Moved)
            {
                endTouchPos = touch.position;
                currentDirection = (endTouchPos - startTouchPos).normalized;
            }
        }
        else
        {
            currentDirection = Vector2.Lerp(currentDirection, Vector2.zero, Time.deltaTime * deceleration);
        }

        velocity = currentDirection * moveSpeed;
        Move(velocity);
    }

    void LateUpdate()
    {
         currentPlayer = GetActivePlayerTransform();

         if (followCam != null && currentPlayer != null)
         {
              followCam.SetTarget(currentPlayer);
        }
    }

    private void Move(Vector2 direction)
{
    if (currentPlayer == null || moveArea == null)
        return;

    Vector3 nextPos = currentPlayer.position + (Vector3)(direction * Time.deltaTime);

    if (moveArea.bounds.Contains(nextPos))
    {
        currentPlayer.position = nextPos;
    }
}

    private Transform GetActivePlayerTransform()
    {
        foreach (Transform child in transform)
        {
            if (child.gameObject.activeSelf)
                return child;
        }
        return null;
    }

}
