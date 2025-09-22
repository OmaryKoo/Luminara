using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;

    private Vector2 startTouchPos;  // 🔹 터치 시작 위치
    private Vector2 endTouchPos;    // 🔹 터치 종료 or 이동 위치

    private Transform currentPlayer;

    private FollowCamera followCam;

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
                Vector2 direction = (endTouchPos - startTouchPos).normalized;
                Move(direction);
            }
        }
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
        if (currentPlayer != null)
            currentPlayer.Translate(direction * moveSpeed * Time.deltaTime);
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
