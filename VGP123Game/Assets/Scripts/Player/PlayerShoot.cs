using UnityEngine;

public class PlayerShoot : MonoBehaviour
{

    [Header("Setup")]
    [SerializeField] private Projectile2D projectilePrefab;
    [SerializeField] private Transform firePoint;
    [SerializeField] private PlayerFacing facing;

    [Header("Tuning")]
    [SerializeField] private float fireCooldown = 0.25f;

    public bool CanShoot { get; private set; } = false;

    private float lastFireTime;

    private void Awake()
    {
        if (facing == null) facing = GetComponent<PlayerFacing>();

    }

    private void Update()
    {
        if (!CanShoot) return;

        if (Input.GetKeyDown(KeyCode.F))
        {
            TryFire();
        }
    }

    public void EnableShooting()
    {
        CanShoot = true;
    }

    private void TryFire()
    {
        if (Time.time < lastFireTime + fireCooldown) return;
        lastFireTime = Time.time;

        Vector2 dir = (facing != null && facing.FacingRight) ? Vector2.right : Vector2.left;

        var proj = Instantiate(projectilePrefab, firePoint.position, Quaternion.identity);
        proj.Fire(dir);
    }

}
