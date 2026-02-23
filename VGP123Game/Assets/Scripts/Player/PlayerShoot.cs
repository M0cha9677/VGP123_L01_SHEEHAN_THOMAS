using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    [Header("Refs")]
    [SerializeField] private Projectile2D _projectilePrefab;
    [SerializeField] private Transform _firePoint;
    [SerializeField] private Animator _anim;

    [Header("Tuning")]
    [SerializeField] private float _fireCooldown = 0.25f;

    private PlayerMovement2D _move;
    private Collider2D _playerCol;

    private bool _canShoot;
    private float _nextFireTime;

    private void Awake()
    {
        _move = GetComponent<PlayerMovement2D>();
        _playerCol = GetComponent<Collider2D>();
        if (_anim == null) _anim = GetComponent<Animator>();
    }

    public void EnableShooting()
    {
        _canShoot = true;
        Debug.Log("Shooting enabled!");
    }

    private void Update()
    {
        bool holding = Input.GetKey(KeyCode.F);

        if (_anim != null)
            _anim.SetBool("isShooting", _canShoot && holding);

        if (!_canShoot) return;
        if (!holding) return;

        if (Time.time < _nextFireTime) return;
        _nextFireTime = Time.time + _fireCooldown;

        ShootOnce();
    }

    private void ShootOnce()
    {
        if (_projectilePrefab == null || _firePoint == null || _move == null)
        {
            Debug.LogError("PlayerShoot missing refs: projectile/firePoint/move.");
            return;
        }

        Vector2 dir = _move.FacingRight ? Vector2.right : Vector2.left;

        // small forward offset so it doesn't spawn inside colliders
        Vector3 spawnPos = _firePoint.position + (Vector3)(dir * 0.1f);

        var proj = Instantiate(_projectilePrefab, spawnPos, Quaternion.identity);

        var projCol = proj.GetComponent<Collider2D>();
        if (projCol != null && _playerCol != null)
            Physics2D.IgnoreCollision(projCol, _playerCol);

        proj.Fire(dir);
    }
}
