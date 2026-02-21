using UnityEngine;

public class PlayerFacing : MonoBehaviour
{

    [SerializeField] private SpriteRenderer sr;

    public bool FacingRight { get; private set; } = true;

    private void Reset()
    {
        sr = GetComponentInChildren<SpriteRenderer>();
    }

    public void SetFacingFromInput(float xInput)
    {
        if (xInput > 0.01f) FacingRight = true;
        else if (xInput < -0.01f) FacingRight = false;

        if (sr != null)
            sr.flipX = !FacingRight;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
