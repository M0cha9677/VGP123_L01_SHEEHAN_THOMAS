using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Collider2D))]
public class PlayerClampToBounds : MonoBehaviour
{
    [SerializeField] private BoxCollider2D levelBounds;
    [SerializeField] private bool recalcEveryFixedUpdate = false; // set true if your collider size changes due to animation
    [SerializeField] private float epsilon = 0.001f;

    private Rigidbody2D rb;
    private Collider2D col;

    private float minX, maxX, maxY;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<Collider2D>();
    }

    private void Start()
    {
        RecalculateLimits();
    }

    public void RecalculateLimits()
    {
        if (levelBounds == null) return;

        Bounds b = levelBounds.bounds;
        Bounds pb = col.bounds;

        float halfW = pb.extents.x;
        float halfH = pb.extents.y;

        minX = b.min.x + halfW;
        maxX = b.max.x - halfW;
        maxY = b.max.y - halfH; // clamp top only
    }

    private void FixedUpdate()
    {
        if (levelBounds == null) return;

        Vector2 p = rb.position;

        // Clamp X
        if (p.x < minX) p.x = minX;
        else if (p.x > maxX) p.x = maxX;

        // Clamp TOP only
        if (p.y > maxY) p.y = maxY;

        rb.position = p; // snap only if needed; no velocity changes
    }
}
