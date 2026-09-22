using UnityEngine;

public class Enemy : Actor
{
    [SerializeField]
    private float noticeRadius = 10f;

    [SerializeField]
    private float moveSpeed = 2f;
    
    [SerializeField] private Rigidbody rb;

    private Transform _target;

    private Weapon _heldWeapon;

    protected override void Awake()
    {
        _target = GameObject.FindGameObjectWithTag("Player").transform;
        _heldWeapon = GetComponentInChildren<Weapon>();
        rb = GetComponent<Rigidbody>();
        base.Awake();
    }

    private void FixedUpdate()
    {
        if (_target == null)
            return;

        float distance = Vector3.Distance(
            transform.position,
            _target.position
        );

        if (distance > noticeRadius)
            return;

        if (_heldWeapon != null && distance <= _heldWeapon.Data.range)
        {
            rb.linearVelocity = Vector3.zero;
            RotateTowardsPlayer();
            RotateWeaponTowardsPlayer();
            Attack();
        }
        else
        {
            // TO-DO: only call method when weapon rotation isn't aligned with player position.
            RotateTowardsPlayer();
            MoveTowardsPlayer();
        }
    }

    private void MoveTowardsPlayer()
    {
        Vector3 direction = (_target.position - transform.position).normalized;
        rb.linearVelocity = direction * moveSpeed;
    }

    private void RotateTowardsPlayer()
    {
        transform.rotation = Quaternion.LookRotation(_target.transform.position - transform.position);
    }

    private void RotateWeaponTowardsPlayer()
    {
        Vector3 direction = _target.position - _heldWeapon.transform.position;
        _heldWeapon.transform.rotation = Quaternion.LookRotation(direction);
    }
}