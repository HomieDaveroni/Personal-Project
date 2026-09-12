using UnityEngine;

public abstract class Actor : MonoBehaviour
{
    [SerializeField]
    private float maxHp = 100f;

    [SerializeField]
    private Weapon weapon;

    [SerializeField]
    private float attackRadius;

    public float Hp { get; private set; }

    public Weapon Weapon => weapon;

    public float AttackRadius => attackRadius;

    protected virtual void Awake()
    {
        Hp = maxHp;
    }

    public virtual void Attack()
    {
        if (weapon == null)
            return;

        weapon.Attack();
    }

    public virtual void TakeDamage(float damage)
    {
        Hp -= damage;

        if (Hp <= 0)
        {
            Die();
        }
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