using UnityEngine;

public class Collectible : MonoBehaviour
{
    public int points = 100;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Collected! +" +  points);
            Destroy(gameObject);
        }
    }
}
