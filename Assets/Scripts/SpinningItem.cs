using UnityEngine;

public class SpinningItem : MonoBehaviour
{
    [SerializeField] private float spinAmount;
    void Update()
    {
        transform.Rotate(0, spinAmount * Time.deltaTime, 0, Space.Self);
    }
}
