using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField]
    private WeaponData data;

    [SerializeField]
    private Transform muzzle;

    public Transform Muzzle { get => muzzle; set => muzzle = value; }

    private float nextAttackTime;

    public WeaponData Data { get => data; set => data = value; }

    private void Start()
    {
        // Find the muzzle of attached weapons to determine where the projectile comes out
        for (int i = 0; i < transform.childCount; i++)
        {
            if (transform.GetChild(i).CompareTag("Weapon"))
            {
                muzzle = transform.GetChild(i);
                break;
            }
        }
    }

    public void Attack()
    {
        if (data == null)
            return;

        if (Time.time < nextAttackTime)
            return;

        nextAttackTime = Time.time + data.attackCooldown;

        Fire();
    }

    private void Fire()
    {
        Projectile projectile = Instantiate(
            data.projectilePrefab,
            muzzle.position,
            muzzle.rotation
        );

        projectile.Initialize(
            data.damage,
            muzzle.forward
        );
    }
}
