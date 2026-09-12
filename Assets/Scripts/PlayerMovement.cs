using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    private Vector2 _move;
    
    private Rigidbody _rigidbody;

    private void Awake()
    {
        
        _rigidbody = GetComponent<Rigidbody>();
        
    }
    
    public void OnMove(InputAction.CallbackContext context)
    {
        _move = context.ReadValue<Vector2>();
    }

    private void Update()
    {
        HandleRotationInput();
    }
    
    private void FixedUpdate()
    {
        movePlayer();
    }

    private void HandleRotationInput()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit))
        {
            transform.LookAt(new Vector3(hit.point.x, transform.position.y, hit.point.z));
        }
    }

    private void movePlayer()
    {
        Vector3 movement = new Vector3(_move.x, 0, _move.y);
        _rigidbody.MovePosition(_rigidbody.position + movement * (moveSpeed * Time.fixedDeltaTime));
    }

}