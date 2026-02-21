using UnityEngine;

public class ShootPowerUp : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;

        var shoot = other.GetComponent<PlayerShoot>();
        if (shoot != null )
        {
            shoot.EnableShooting();
        }

        Destroy(gameObject);

    }
}
