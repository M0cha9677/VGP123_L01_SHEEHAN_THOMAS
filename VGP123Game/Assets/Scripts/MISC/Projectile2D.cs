using UnityEngine;

public class Projectile2D : MonoBehaviour
{
    [SerializeField] private float speed = 12f;
    [SerializeField] private float lifeTime = 2f;

    private Rigidbody2D _rb;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    public void Fire(Vector2 dir)
    {
        _rb.linearVelocity = dir.normalized * speed;
        Destroy(gameObject, lifeTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Projectile hit: " + other.name + " | tag=" + other.tag + " | layer=" + LayerMask.LayerToName(other.gameObject.layer));

        // Ignore these entirely
        if (other.CompareTag("Player")) return;
        if (other.CompareTag("MainCamera")) return;

        if (other.CompareTag("Collectible")) return;
        if (other.CompareTag("PowerUp")) return;

        // Anything else = destroy projectile
        Destroy(gameObject);
    }
    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
