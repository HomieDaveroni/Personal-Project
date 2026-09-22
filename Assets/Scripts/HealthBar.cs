using DefaultNamespace.StringConverts;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    private Slider _healthBar;
    private  float _hp;
    private Player _player;
    private TextMeshProUGUI _healthText;

    protected void Start()
    {
        _healthBar = GetComponent<Slider>();
        _player = GameObject.FindGameObjectWithTag(GameObjectTags.Player).GetComponent<Player>();
        _healthText = GameObject.Find(GameObjectTags.HpValueText).GetComponent<TextMeshProUGUI>();
    }

    private void Update()
    {
        _hp = _player.Hp;
        _healthBar.value = _hp;
        _healthText.text = $"{_healthBar.value}/100";
    }
}
