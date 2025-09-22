using UnityEngine;

public class LightOrb : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            FindFirstObjectByType<PlayerEvolution>()?.CollectLightOrb();
            Destroy(gameObject);
        }
    }
}
