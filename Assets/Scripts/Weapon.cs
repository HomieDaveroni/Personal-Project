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