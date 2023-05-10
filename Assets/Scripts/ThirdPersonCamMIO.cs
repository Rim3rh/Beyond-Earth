using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCamMIO : MonoBehaviour
{
    
    public Rigidbody _rb;
    public Transform playerObj;
    public Transform player;
    public Transform orientation;
    public float _rotateSpeed;



    private PlayerInputActions playerInputActions;
    private Vector2 _moveInput;
    void Start()
    {
        playerInputActions = new PlayerInputActions();
        playerInputActions.PlayerMov.Enable();
    }

    // Update is called once per frame
    void Update()
    {

        if (GameManager.Instance._canMove)
        {
            _moveInput = playerInputActions.PlayerMov.Movement.ReadValue<Vector2>();

            Vector3 viewDir = player.position - new Vector3(transform.position.x, player.position.y, transform.position.z);
            orientation.forward = viewDir.normalized;

            float horizontalInput = Input.GetAxis("Horizontal");
            float VerticalInput = Input.GetAxis("Vertical");

            Vector3 inputDir = orientation.forward * VerticalInput + orientation.right * horizontalInput;

            if (inputDir != Vector3.zero)
                playerObj.forward = Vector3.Slerp(playerObj.forward, inputDir.normalized, Time.deltaTime * _rotateSpeed);
        }
        

    }
    
}
