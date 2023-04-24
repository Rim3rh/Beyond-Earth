using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class CharacterController : MonoBehaviour
{
    public static bool _holdingMainTank;
    public static bool _holdingSecondaryTank;


    private PlayerInputActions playerInputActions;
    private Vector2 _moveInput;
    private Rigidbody _rb;
    

    public GameObject _pickUpSlot;


 

    private GameObject _item;
    private bool _isHolding;
    private float timer, timer2;

    void Awake()
    {
        timer2 = 0.5f;
        timer = 0f;
        _isHolding = false;
        _holdingSecondaryTank = false;
        _holdingMainTank = true ;
        
        _rb = GetComponent<Rigidbody>();

        //Adding new input system, First add reference to input system class
        playerInputActions = new PlayerInputActions();
        //now, we want to acces the class, acces de PlayerMov action map, and then the Interact Action, followed by the preformed stage
        // then you add that to that the name of the new class you have created(se deberia crear sola pero ns)
        //playerInputActions.PlayerMov.Interact.started += Interact;
        playerInputActions.Enable();
        playerInputActions.PlayerMov.Interact.started += Interact;
        

       
    }

    private void Interact(InputAction.CallbackContext context)
    {
        Debug.Log(context);

    }

    void Update()
    {
        _moveInput = playerInputActions.PlayerMov.Movement.ReadValue<Vector2>();
        Rotation();
       

        if (_item != null)
        {

            if (Input.GetKeyDown(KeyCode.E) && !_isHolding && timer <= 0)
            {
                
               
                _isHolding = true;
                timer2 = 0.5f;
            }
            if (Input.GetKeyDown(KeyCode.E) && _isHolding && timer2 <= 0)
            {
                
                
                _isHolding = false;
                _item = null;
                timer = 0.5f;
                GameManager.Instance._speed = 10;
            }
            if (_isHolding)
            {
                _item.transform.position = _pickUpSlot.transform.position;
                timer2 -= Time.deltaTime;
                GameManager.Instance._speed = 6;
            }   
            if (!_isHolding)
            {
                timer -= Time.deltaTime;
                
            }



        }      
        
       
    }


    private void FixedUpdate()
    {
        
        _rb.velocity = new Vector3(_moveInput.x * GameManager.Instance._speed, 0, _moveInput.y * GameManager.Instance._speed);
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
        if (other.CompareTag("Pickeable"))
        {
            Debug.Log("GOLA");
            _item = other.gameObject;
            GameManager.Instance.HudInteractOn();
        }

    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Pickeable"))
        {
            _item = null;
            GameManager.Instance.HudInteractOff();
        }

    }




}
