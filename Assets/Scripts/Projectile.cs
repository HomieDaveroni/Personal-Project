using UnityEngine;

public class Projectile : MonoBehaviour
{
    private float _damage;
    private Vector3 _direction;

    [SerializeField]
    private float speed = 15f;

    [SerializeField]
    private float lifetime = 5f;

    private MeshRenderer _meshRenderer;

    private void Start()
    {
        _meshRenderer = GetComponent<MeshRenderer>();
    }

    public void Initialize(float damage, Vector3 direction)
    {
        this._damage = damage;
        this._direction = direction.normalized;

        Destroy(gameObject, lifetime);
    }

    private void Update()
    {
        if (Physics.Raycast(new Ray(transform.position, _direction), out RaycastHit hit, speed * Time.deltaTime))
        {
            transform.position = hit.point;
            hit.collider.SendMessage("TakeDamage", _damage, SendMessageOptions.DontRequireReceiver);
            _meshRenderer.enabled = false;
            Destroy(gameObject, lifetime);
            Destroy(this);
        }
        else
        {
            transform.Translate(_direction * (speed * Time.deltaTime));
        }
    }

}