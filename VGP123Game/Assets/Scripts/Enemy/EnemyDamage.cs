using UnityEngine;

public class EnemyDamage : MonoBehaviour
{

    public int damage = 1;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.gameObject.CompareTag("Player")) return;

        var power = collision.gameObject.GetComponent<PlayerPowerUp>();
        if (power != null && power.isPoweredUp)
        {
            Debug.Log("Enemy Defeated while Powered-Up");
            Destroy(gameObject);
            return;
        }

        var health = collision.gameObject.GetComponent<PlayerHealth>();
        if (health != null) health.TakeDamage(damage);
    }
}
