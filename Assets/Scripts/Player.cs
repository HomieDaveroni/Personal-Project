using UnityEngine;
using UnityEngine.InputSystem;

public class Player : Actor
{
    private void Start()
    {
        Projectile projectilePrefab = Resources.Load<Projectile>("Booger_Projectile");

        WeaponData data = ScriptableObject.CreateInstance<WeaponData>();
        data.damage = 10f;
        data.attackCooldown = 0.5f;
        data.range = 10f;
        data.projectilePrefab = projectilePrefab;

        Weapon weapon = gameObject.AddComponent<Weapon>();
        weapon.Data = data;
        weapon.Muzzle = transform.Find("Gun");
        EquipWeapon(weapon);
    }

    private void Update()
    {
    }
}
