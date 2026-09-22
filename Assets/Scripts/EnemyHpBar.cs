using UnityEngine;
using UnityEngine.UI;

public class EnemyHpBar : MonoBehaviour
{
    private Slider _healthBar;
    private Enemy _enemy;
    void Start()
    {
        _healthBar = GetComponent<Slider>();
        _enemy = GetComponentInParent<Enemy>();
        _healthBar.maxValue = _enemy.Hp;
    }
    
    void Update()
    {
        Quaternion rotation = Camera.main.transform.rotation;
        transform.LookAt(transform.position + rotation * Vector3.forward, rotation * Vector3.up);
        _healthBar.value = _enemy.Hp;
    }
}
