using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTem : MonoBehaviour
{
    private Vector2 _moveInput;
    private Rigidbody _rb;
    private PlayerInputActions playerInputActions;
    void Awake()
    {
        _rb = GetComponent<Rigidbody>();
        playerInputActions = new PlayerInputActions();
        playerInputActions.PlayerMov.Enable();
    }
    void Update()
    {
        _moveInput = playerInputActions.PlayerMov.Movement.ReadValue<Vector2>();
    }
    private void FixedUpdate()
    {
        _rb.velocity = new Vector3(_moveInput.x * GameManager.Instance._speed, _rb.velocity.y, _moveInput.y * GameManager.Instance._speed);
    }
}
