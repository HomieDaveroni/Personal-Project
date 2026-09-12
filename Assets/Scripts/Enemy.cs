using UnityEngine;

public class Enemy : Actor
{
    [SerializeField]
    private float noticeRadius = 10f;

    [SerializeField]
    private float moveSpeed = 2f;

    private Transform _target;

    protected override void Awake()
    {
        _target = GameObject.FindGameObjectWithTag("Player").transform;
        base.Awake();
    }

    private void Update()
    {
        if (_target == null)
            return;

        float distance = Vector3.Distance(
            transform.position,
            _target.position
        );

        if (distance <= noticeRadius && distance >= AttackRadius)
        {
            MoveTowardsTarget();

            if (Weapon != null)
            {
                Attack();
            }
        }
    }

    private void MoveTowardsTarget()
    {
        Vector3 direction =
            (_target.position - transform.position).normalized;

        transform.position +=
            direction * (moveSpeed * Time.deltaTime);
    }
}