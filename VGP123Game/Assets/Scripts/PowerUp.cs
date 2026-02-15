using UnityEngine;

public class PowerUp : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;

        var p = other.GetComponent<PlayerPowerUp>();
        if (p != null) p.ActivatePowerUp();

        Debug.Log("Power_UP Collected");
        Destroy(gameObject);
        

        
        
    }
}
