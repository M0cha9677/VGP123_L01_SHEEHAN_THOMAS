using UnityEngine;

public class ShootPowerUp : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;

        PlayerShoot shooter = other.GetComponent<PlayerShoot>();

        if (shooter != null)
        {
            shooter.EnableShooting();
            Debug.Log("Player picked up shooting power-up.");
        }
        else
        {
            Debug.LogWarning("PlayerShoot component not found on player.");
        }

        Destroy(gameObject);
    }
}
