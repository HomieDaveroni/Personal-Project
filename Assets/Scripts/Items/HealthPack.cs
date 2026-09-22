using DefaultNamespace.StringConverts;
using UnityEngine;

namespace DefaultNamespace.Items
{
    public class HealthPack : MonoBehaviour
    {
        [SerializeField]
        private float healthAmount;
        private Player player; 

        private void Awake()
        {
            player = GameObject.FindGameObjectWithTag(GameObjectTags.Player).GetComponent<Player>();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag(GameObjectTags.Player) && player.Hp < player.GetMaxHp())
            {
                player.Heal(healthAmount);
                Destroy(gameObject);
            }
        }
    }
}