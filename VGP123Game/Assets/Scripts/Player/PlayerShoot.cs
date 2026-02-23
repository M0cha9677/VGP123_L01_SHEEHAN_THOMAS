using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    [Header("Setup")]
    [SerializeField] private Projectile2D _projectilePrefab;
    [SerializeField] private Transform _firePoint;
    [SerializeField] private PlayerMovement2D _facing;
    [SerializeField] private Animator _anim;

    [Header("Tuning")]
    [SerializeField] private float _fireCooldown = 0.25f;

    private float _lastFireTime;

    private void Awake()
    {
        if (_facing == null) _facing = GetComponent<PlayerMovement2D>();
        if (_anim == null) _anim = GetComponent<Animator>();
    }

    private void Update()
    {
        bool holdingShoot = Input.GetKey(KeyCode.F);

        // 1️⃣ Control animation directly from key state
        if (_anim != null)
            _anim.SetBool("isShooting", holdingShoot);

        // 2️⃣ Fire projectile on cooldown while key held
        if (holdingShoot && Time.time >= _lastFireTime + _fireCooldown)
        {
            _lastFireTime = Time.time;
            Shoot();
        }
    }

    private void Shoot()
    {
        Vector2 dir = (_facing != null && _facing.FacingRight)
            ? Vector2.right
            : Vector2.left;

        var proj = Instantiate(_projectilePrefab, _firePoint.position, Quaternion.identity);
        proj.Fire(dir);
    }

}
