using DefaultNamespace.StringConverts;
using UnityEngine;

public class Minimap : MonoBehaviour
{
    private GameObject _player;

    private void Awake()
    {
        _player = GameObject.FindGameObjectWithTag(GameObjectTags.Player);
    }

    void LateUpdate()
    {
        transform.position = new Vector3(_player.transform.position.x, transform.position.y, _player.transform.position.z);
    }
}
