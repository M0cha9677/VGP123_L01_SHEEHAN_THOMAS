using UnityEngine;

public class Death : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
        var health = collision.gameObject.GetComponent<PlayerHealth>();
        if (health != null) health.TakeDamage(999);
        }
    }
}
