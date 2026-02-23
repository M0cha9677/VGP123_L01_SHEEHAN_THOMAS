using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(Collider2D), typeof(SpriteRenderer))]
[RequireComponent(typeof(Animator))]

public class PlayerMovement2D : MonoBehaviour
{
    public LayerMask groundLayer;

    public float moveSpeed = 5f;
    public float jumpForce = 10f;
    public float groundCheckRadius = 0.02f;
    public bool FacingRight => !_sr.flipX;

    private Rigidbody2D _rb;
    private Collider2D _collider;
    private SpriteRenderer _sr;
    private Animator _anim;

    private bool _isGrounded = false;
    private Vector2 groundCheckPos => CalculateGroundCheck();
    private Vector2 CalculateGroundCheck()
    {
        Bounds bounds = _collider.bounds;
        return new Vector2(bounds.center.x, bounds.min.y);
    }

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _collider = GetComponent<Collider2D>();
        _sr = GetComponent<SpriteRenderer>();
        _anim = GetComponent<Animator>();


        //if (groundCheckTransform == null) 
        //{
        //      groundCheckTransform = new GameObject("GroundCheck");
        //      groundCheckTransform.transform.SetParent(transform);
        //      groundCheckTransform.transform.localPosition = Vector3.zero
        //}
    }

    void Update()
    {
        _isGrounded = Physics2D.OverlapCircle(groundCheckPos, groundCheckRadius, groundLayer);

        float horizontalInput = Input.GetAxis("Horizontal");
        bool jumpInput = Input.GetButtonDown("Jump");

        Vector2 velocity = _rb.linearVelocity;
        velocity.x = horizontalInput * moveSpeed;
        _rb.linearVelocity = velocity;

        if (horizontalInput != 0) SpriteFlip(horizontalInput);

        if (jumpInput && _isGrounded)
        {
            _rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
        }

        _anim.SetFloat("moveInput", Mathf.Abs(horizontalInput));
        _anim.SetBool("isGrounded", _isGrounded);
        _anim.SetFloat("yVel", _rb.linearVelocity.y);
        

    }


    private void SpriteFlip(float horizontalInput) => _sr.flipX = (horizontalInput < 0);
}
