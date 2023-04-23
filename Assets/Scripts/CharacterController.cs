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

    public GameObject _oxygenSlot;


    public static bool _holdingMainTank;
    public static bool _holdingSecondaryTank;

    private GameObject _item;

    void Awake()
    {
        _holdingSecondaryTank = false;
        _holdingMainTank = true ;
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
        
        if (_item != null)
        {
            Debug.Log(_item);
            _item.transform.position = _oxygenSlot.transform.position;
        }
        


        Debug.Log(_holdingMainTank);
        Debug.Log("SEGUNDO" + _holdingSecondaryTank);




        Rotation();
        _moveInput = playerInputActions.PlayerMov.Movement.ReadValue<Vector2>();



       



    }


    private void FixedUpdate()
    {
        Debug.Log("HGOAL");
        _rb.velocity = new Vector3(_moveInput.x * _speed, 0, _moveInput.y * _speed);
    }


    private void Rotation()
    {
        if (_moveInput.x > 0)
        {
            transform.eulerAngles = new Vector3(0, 90, 0);
        }
        if (_moveInput.x < 0)
        {
            transform.eulerAngles = new Vector3(0, -90, 0);
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

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Finish"))
        {
            Debug.Log("Gola");
            _item = other.GetComponent<GameObject>();
            Debug.Log(other
               
                
                
                );
        }

    }




}
