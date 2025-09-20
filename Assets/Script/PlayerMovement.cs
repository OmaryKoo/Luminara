using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
  public float moveSpeed = 5f;
    private Vector2 startTouchPos;
    private Vector2 endTouchPos;

    private Transform currentPlayer;

    private void Update()
    {
        currentPlayer = GetActivePlayerTransform();

        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
                startTouchPos = touch.position;

            else if (touch.phase == TouchPhase.Ended)
            {
                endTouchPos = touch.position;
                Vector2 direction = (endTouchPos - startTouchPos).normalized;
                Move(direction);
            }
        }
    }

    private void Move(Vector2 direction)
    {
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
