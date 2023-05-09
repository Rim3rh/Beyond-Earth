using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class CharacterController : MonoBehaviour
{

    private Vector2 _moveInput;
    private Rigidbody _rb;
    private PlayerInputActions playerInputActions;

    public Transform orientation;



    private Vector3 _moveDir;
    private float _rbDrag;



    void Awake()
    {
        _rb = GetComponent<Rigidbody>();
        playerInputActions = new PlayerInputActions();
        playerInputActions.PlayerMov.Enable();
        _rbDrag = 6f;
    }





    void Update()
    {
        if (GameManager.Instance._canMove)
        {
            _moveInput = playerInputActions.PlayerMov.Movement.ReadValue<Vector2>();

            _rb.drag = _rbDrag;

            Debug.Log(_moveDir);
            if (_moveInput == Vector2.zero)
            {
                _rb.velocity = Vector3.zero;
            }
        }
     

    }
    private void FixedUpdate()
    {
        if (GameManager.Instance._canMove)
        {
            Movement();
        }
       
    }
    private void Movement()
    {
        _moveDir = orientation.forward * _moveInput.y + orientation.right * _moveInput.x;


      
        _rb.velocity = _moveDir.normalized * GameManager.Instance._speed ;
        
      

    }
}