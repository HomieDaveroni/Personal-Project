using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    private Vector2 _move;
    private float _skinWidth = 0.015f;
    
    private Rigidbody _rigidbody;

    private void Awake()
    {
        
        _rigidbody = GetComponent<Rigidbody>();
        
    }
    
    public void OnMove(InputAction.CallbackContext context)
    {
        _move = context.ReadValue<Vector2>();
    }
    
    private void FixedUpdate()
    {
        HandleRotationInput();
        MovePlayer();
    }

    private void HandleRotationInput()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            Vector3 lookPoint = new Vector3(hit.point.x, transform.position.y, hit.point.z);
            Vector3 direction = (lookPoint - transform.position).normalized;

            if (direction.sqrMagnitude > 0.0001f)
            {
                Quaternion targetRotation = Quaternion.LookRotation(direction);
                _rigidbody.MoveRotation(targetRotation);
            }
        }
    }

    private void MovePlayer()
    {
        Vector3 inputVelocity = new Vector3(_move.x, 0, _move.y) * (moveSpeed * Time.fixedDeltaTime);
        if (inputVelocity.sqrMagnitude < 0.0000001f)
        {
            return;
        }

        Vector3 moveVector = CollideAndSlide(inputVelocity, _rigidbody.position, 0, inputVelocity);
        _rigidbody.MovePosition(_rigidbody.position + moveVector);
    }

    private Vector3 CollideAndSlide(Vector3 velocity, Vector3 position, int depth, Vector3 initVelocity)
    {
        if (depth >= 5)
        {
            return Vector3.zero;
        }

        float distance = velocity.magnitude + _skinWidth;
        float radius = GetComponent<SphereCollider>().radius;
        
        RaycastHit hit;
        if (Physics.SphereCast(position, radius, velocity.normalized, out hit, distance))
        {
            Vector3 snapToSurface = velocity.normalized * (hit.distance - _skinWidth);
            Vector3 leftover = velocity - snapToSurface;

            if (snapToSurface.magnitude <= _skinWidth)
            {
                snapToSurface = Vector3.zero;
            }
            float scale = 1 - Vector3.Dot(new Vector3(hit.normal.x, 0, hit.normal.z).normalized, - new Vector3(initVelocity.x, 0, initVelocity.z).normalized);
            leftover = ProjectAndScale(new Vector3(leftover.x, 0, leftover.z), new Vector3(hit.normal.x, 0, hit.normal.z).normalized);
            leftover *= scale;

            return snapToSurface + CollideAndSlide(leftover, position + snapToSurface, depth + 1, initVelocity);
        }

        return velocity;
    }

    private Vector3 ProjectAndScale(Vector3 vec, Vector3 normal)
    {
        float mag = vec.magnitude;
        vec = Vector3.ProjectOnPlane(vec, normal).normalized;
        return vec *= mag;
    }

}