using UnityEngine;

public class ScoreCollectible : MonoBehaviour
{
    [SerializeField] private int scoreValue = 100;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;

        ScoreManager.Instance.AddScore(scoreValue);

        Destroy(gameObject);
    }
}
