using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class CharacterController : MonoBehaviour
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
        Rotation();
    }
    private void FixedUpdate()
    {
        _rb.velocity = new Vector3(_moveInput.x * GameManager.Instance._speed, _rb.velocity.y, _moveInput.y * GameManager.Instance._speed);
    }
    private void Rotation()
    {
        if (_moveInput.y != 0 || _moveInput.x != 0)
        {
            float _targetAngle = Mathf.Atan2(_moveInput.x, _moveInput.y) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0f, _targetAngle, 0f);
        }
    }
}