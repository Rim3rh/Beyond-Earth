using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.EventSystems;


public class CharacterController : MonoBehaviour
{

    private Vector2 _moveInput;
    private Rigidbody _rb;
    private PlayerInputActions playerInputActions;

    public Transform orientation;



    private Vector3 _moveDir;
    private float _rbDrag;

    public Animator _playerAnim;



    public GameObject _optionsMenu, _resumeButton;
    //private bool _openedMenu;

    void Awake()
    {
        Cursor.visible = false;
        _optionsMenu.SetActive(false);
        //_openedMenu = false;

        _rb = GetComponent<Rigidbody>();
        playerInputActions = new PlayerInputActions();
        playerInputActions.PlayerMov.Enable();
        playerInputActions.PlayerMov.PAUSE.started += PAUSE_started;
        _rbDrag = 6f;
    }

    private void PAUSE_started(InputAction.CallbackContext obj)
    {

        if (GameManager.Instance._openedMenu)
        {
            EventSystem.current.SetSelectedGameObject(null);
            

          //  Debug.Log("CERRAR");
            Time.timeScale = 1f;
            _optionsMenu.SetActive(false);
           GameManager.Instance._openedMenu = false;
        }
        else
        {
            EventSystem.current.SetSelectedGameObject(null);
            EventSystem.current.SetSelectedGameObject(_resumeButton);
           // Debug.Log("ABIR");
            _optionsMenu.SetActive(true);
            Time.timeScale = 0f;
           GameManager.Instance._openedMenu = true;
        }

        
    }

    void Update()
    {

        Animations();
        

        if (GameManager.Instance._canMove)
        {
            _moveInput = playerInputActions.PlayerMov.Movement.ReadValue<Vector2>();

            _rb.drag = _rbDrag;

            //Debug.Log(_moveDir);
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


    private void Animations()
    {
        if (_moveInput != Vector2.zero)
        {
            _playerAnim.SetBool("Moving", true);
        }
        else
        {
            _playerAnim.SetBool("Moving", false);
        }
    }
    private void Movement()
    {
        _moveDir = orientation.forward * _moveInput.y + orientation.right * _moveInput.x;


      
        _rb.velocity = _moveDir.normalized * GameManager.Instance._speed ;
        
      

    }
}