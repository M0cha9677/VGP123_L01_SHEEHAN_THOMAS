using UnityEngine;

public class CameraaFollowBounds2D : MonoBehaviour
{

    public Transform target;
    public BoxCollider2D bounds;

    public float smoothTime = 0.15f;

    private Camera cam;
    private Vector3 velocity;

    private float minX, maxX, minY, maxY;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        cam = GetComponent<Camera>();
        RecalculateBounds();
    }

    public void RecalculateBounds()
    {
        if (bounds == null) return;

        float camHalfHeight = cam.orthographicSize;
        float camHalfWidth = camHalfHeight * cam.aspect;

        Bounds b = bounds.bounds;

        minX = b.min.x + camHalfWidth;
        maxX = b.max.x - camHalfWidth;

        minY = b.min.y + camHalfHeight;
        maxY = b.max.y - camHalfHeight;

    }

    // Update is called once per frame
    private void LateUpdate()
    {
        if (target == null || bounds == null) return;

        Vector3 desired = new Vector3(target.position.x, target.position.y, transform.position.z);

        desired.x = Mathf.Clamp(desired.x, minX, maxX);
        desired.y = Mathf.Clamp(desired.y, minY, maxY);

        transform.position = Vector3.SmoothDamp(transform.position, desired, ref velocity, smoothTime);
    }
}
