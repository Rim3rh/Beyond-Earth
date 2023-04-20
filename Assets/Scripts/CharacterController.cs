using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class CharacterController : MonoBehaviour
{

  
   



    private PlayerInputActions playerInputActions;
    private Vector2 _moveInput;
    private Rigidbody _rb;
    private int _speed;
    
    
    void Awake()
    {
       
        _speed = 10;
        _rb = GetComponent<Rigidbody>();

        //Adding new input system, First add reference to input system class
        playerInputActions = new PlayerInputActions();
        //now, we want to acces the class, acces de PlayerMov action map, and then the Interact Action, followed by the preformed stage
        // then you add that to that the name of the new class you have created(se deberia crear sola pero ns)
        //playerInputActions.PlayerMov.Interact.started += Interact;
        playerInputActions.PlayerMov.Enable();

       
    }

    

    void Update()
    {
        Rotation();
        _moveInput = playerInputActions.PlayerMov.Movement.ReadValue<Vector2>();
        _rb.velocity = new Vector3(_moveInput.x, 0, _moveInput.y)* _speed;


      
       


    }

 

    private void Rotation()
    {
        if(_moveInput.x != 0)
        {
            transform.eulerAngles = new Vector3(0, 90, 0) * _moveInput.x;
        }
        if (_moveInput.y > 0)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
        if (_moveInput.y < 0)
        {
            transform.eulerAngles = new Vector3(0, -180, 0);
        }


    }




}
