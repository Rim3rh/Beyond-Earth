using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    private PlayerInputActions _cameraInputActions;

    private Vector3 _moveDir;
    void Awake()
    {
        _cameraInputActions = new PlayerInputActions();
        //_cameraInputActions.PlayerMov.CameraRotation.performed += CameraRotation_performed;
        _cameraInputActions.PlayerMov.Enable();
    }

 

    // Update is called once per frame
    void Update()
    {
        _moveDir = _cameraInputActions.PlayerMov.CameraRotation.ReadValue<Vector2>();


        Vector3 inputDir = new Vector3(0, 0, 0);

        if (Input.GetKey(KeyCode.W)) inputDir.z = -1f;
        if (Input.GetKey(KeyCode.S)) inputDir.z = +1f;
        if (Input.GetKey(KeyCode.A)) inputDir.x = -1f;
        if (Input.GetKey(KeyCode.D)) inputDir.x = +1f;
        Debug.Log(_moveDir);

        Vector3 _prueba = transform.up * inputDir.z + transform.right * inputDir.x;

        float moveSpeed = 50f;
        transform.position += _prueba * moveSpeed * Time.deltaTime;




    }
}
