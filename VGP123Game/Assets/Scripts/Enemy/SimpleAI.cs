using UnityEngine;

public class SimpleAI : MonoBehaviour
{

    public float speed = 2f;
    public float patrolDistance = 7f;

    private Vector3 startPos;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(
            startPos.x + Mathf.PingPong(Time.time * speed, patrolDistance),
            transform.position.y,
            transform.position.z);
    }
}
