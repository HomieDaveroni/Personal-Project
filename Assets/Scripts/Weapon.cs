using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField]
    private WeaponData data;

    [SerializeField]
    private Transform muzzle;

    private float nextAttackTime;

    public WeaponData Data => data;

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