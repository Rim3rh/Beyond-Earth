using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class CharacterController : MonoBehaviour
{



    
    private Vector2 _moveInput;
    private Rigidbody _rb;
    

    public GameObject _pickUpSlot;

    private PlayerInputActions playerInputActions;


    
    private bool _isHolding;
    private float timer, timer2;
    private GameObject _itemTem;


    private bool _timer2Runing, _timerRuning;

    void Awake()
    {
        playerInputActions = new PlayerInputActions();
        timer2 = 0.5f;
        timer = 0f;
        _isHolding = false;
        
        _rb = GetComponent<Rigidbody>();


        playerInputActions.PlayerMov.Interact.started += Interact_started;
        playerInputActions.PlayerMov.Enable();
    }

    private void Interact_started(InputAction.CallbackContext context)
    {
        if (_itemTem != null)
        {
            //COGER
            if (context.started && !_isHolding && timer <= 0)
            {
                _timerRuning = false;
         
                GameManager.Instance._item = _itemTem;
                _isHolding = true;
                timer2 = 0.5f;
                GameManager.Instance._speed = 6;
                GameManager.Instance.HudInteractOff();
                _timer2Runing = true;
            }
            //SOLTAR
            if (context.started && _isHolding && timer2 <= 0)
            {
                _timer2Runing = false;
                _itemTem = null;
                GameManager.Instance._item = _itemTem;
                _isHolding = false;
                timer = 0.5f;
                GameManager.Instance._speed = 10;
                GameManager.Instance.HudInteractOn();
                _timerRuning = true;
            }
        }
    }
    void Update()
    {

        _moveInput = playerInputActions.PlayerMov.Movement.ReadValue<Vector2>();
        Rotation();
        
            if (_isHolding)
            {

                GameManager.Instance._item.transform.position = _pickUpSlot.transform.position;
                timer2 -= Time.deltaTime;
            }   
            if (_timerRuning)
            {
                timer -= Time.deltaTime;
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
        if (other.CompareTag("Pickeable") || ((other.gameObject.CompareTag("Oxigeno") && !GameManager.Instance._holdingMainTank)) && !_isHolding)
        {
            _itemTem = other.gameObject;
            GameManager.Instance.HudInteractOn();
        }


    }

    
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Pickeable") || ((other.CompareTag("Oxigeno") && !GameManager.Instance._holdingMainTank)) && !_isHolding)
        {
            _itemTem = null;
            GameManager.Instance.HudInteractOff();
        }
    }
}
