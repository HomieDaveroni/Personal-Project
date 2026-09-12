using UnityEngine;

[CreateAssetMenu(
    fileName = "WeaponData",
    menuName = "Game/Weapon Data"
)]
public class WeaponData : Item
{
    public float damage = 10f;

    public float attackCooldown = 0.5f;

    public float range = 10f;

    public Projectile projectilePrefab;
}