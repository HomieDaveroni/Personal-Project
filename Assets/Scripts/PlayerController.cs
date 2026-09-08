using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float speed = 10;
    [SerializeField] private InputAction moveAction;
    private Vector2 moveInput;
    private Rigidbody playerRb;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        moveAction.Enable();
    }

    // Update is called once per frame
    void Update()
    {
        moveInput = moveAction.ReadValue<Vector2>();
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    private void MovePlayer()
    {
        var horizontalInput = moveInput.x;
        var verticalInput = moveInput.y;
        
        var moveDirection = new Vector3(horizontalInput, 0, verticalInput);
        
        playerRb.MovePosition(playerRb.position + moveDirection * (speed * Time.fixedDeltaTime));
    }
}

