using UnityEngine;
using UnityEngine.InputSystem;

public class Player : Actor
{
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Attack();
        }
    }

    public void OnAttack(InputAction.CallbackContext context)
    {
        if (Weapon != null)
        {
            
        }
    }

    public override void Attack()
    {
        base.Attack();
    }
}