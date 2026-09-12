using System;
using UnityEngine;

namespace DefaultNamespace
{
    public class CameraController : MonoBehaviour
    {
        [SerializeField] private Transform target;
        [SerializeField] private Vector3 targetOffset;
        [SerializeField] private float movementSpeed;

        private void Update()
        {
            MoveCamera();
        }

        void MoveCamera()
        {
            transform.position = Vector3.Lerp(transform.position, target.position + targetOffset, movementSpeed * Time.deltaTime);
        }
    }
}