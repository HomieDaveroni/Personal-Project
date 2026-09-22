using UnityEngine;

public abstract class Actor : MonoBehaviour
{
    [SerializeField]
    protected float maxHp = 100f;

    [SerializeField]
    private Weapon weapon;
    
    [SerializeField] private WeaponData weaponData;

    public float Hp { get; private set; }

    public Weapon Weapon => weapon;
    
    
    public virtual void Attack()
    {
        if (weapon != null)
            weapon.Attack();
    }

    public virtual void TakeDamage(float damage)
    {
        Hp -= damage;
        Debug.Log($"{gameObject.name}: {damage} damage");

        if (Hp <= 0)
        {
            Die();
        }
    }

    protected virtual void Awake()
    {
        Hp = maxHp;
    }

    protected virtual void Start()
    {
        Weapon weapon = gameObject.AddComponent<Weapon>();
        weapon.Data = weaponData;
        EquipWeapon(weapon);
    }

    protected virtual void Die()
    {
        Destroy(gameObject);
    }

    public void EquipWeapon(Weapon newWeapon)
    {
        weapon = newWeapon;
    }
}