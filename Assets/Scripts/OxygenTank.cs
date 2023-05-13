using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OxygenTank : MonoBehaviour
{

    private bool _inRange;
    public GameObject _oxygenSlot, _secondaryTank, _oxygenDrop, _runOxygenSlot;
    public MeshRenderer _oxygenRender;
    [SerializeField] Color _myColor, _myColor2;
    private PlayerInputActions _playerInputActions;

    private Vector2 _moveInput;

    

    public GameObject _player;
    void Start()
    {
        _oxygenRender = GetComponent<MeshRenderer>();
        _inRange = false;
        _playerInputActions = new PlayerInputActions();
        _playerInputActions.PlayerMov.ChangeTank.started += ChangeTank_started;
        _playerInputActions.PlayerMov.Enable();
    }

    private void ChangeTank_started(UnityEngine.InputSystem.InputAction.CallbackContext context)
    {
        if (!PickUpScript._isHolding && GameManager.Instance._holdingSecondaryTank)
        {
            GameManager.Instance.timer -= Time.deltaTime;
            if (_inRange)
            {
                if (context.started && GameManager.Instance.timer < 0)
                {
                    _secondaryTank.transform.position = _oxygenDrop.transform.position;
                    GameManager.Instance._holdingMainTank = true;
                    GameManager.Instance._holdingSecondaryTank = false;
                    GameManager.Instance.timer2 = 0.5f;
                }
            }
        }
    }

    void Update()
    {

        _moveInput = _playerInputActions.PlayerMov.Movement.ReadValue<Vector2>();
        SetLimits();
       // _oxygenRender.material.color = Color.Lerp(_myColor, _myColor2, GameManager.Instance._tank1OxygenLevel / 100);
        if (!PickUpScript._isHolding && GameManager.Instance._holdingSecondaryTank)
        {
            GameManager.Instance.timer -= Time.deltaTime;
        }
        if (GameManager.Instance._holdingMainTank)
        {
            //Quaternion rotation = Quaternion.Euler(90, 100, 100);
            if (_moveInput != Vector2.zero)
            {

              
                    transform.eulerAngles =  new Vector3(115, _player.transform.eulerAngles.y, 0);
                    // transform.eulerAngles = new Vector3 (115, _player.transform.eulerAngles.y, 0);
                    //transform.position = _runOxygenSlot.transform.position;
                    transform.position = Vector3.Lerp(transform.position, _runOxygenSlot.transform.position, 0.5f);
             
          

            }
            else
            {


               
                    transform.eulerAngles = new Vector3(90, _player.transform.eulerAngles.y, 0);
                    //   transform.eulerAngles = new Vector3(90, _player.transform.eulerAngles.y, 0);
                    //transform.position = _oxygenSlot.transform.position;
                    transform.position = Vector3.Lerp(transform.position, _oxygenSlot.transform.position, 0.5f);
                    //transform.position = Vector3.Lerp(_runOxygenSlot.transform.position, _oxygenSlot.transform.position, 0.5f);
              

            }
            
            


            //oxygen level goes down
            GameManager.Instance._tank1OxygenLevel -= Time.deltaTime * 2;
        }
    }
                   
    private void SetLimits()
    {
        GameManager.Instance._tank1OxygenLevel = (GameManager.Instance._tank1OxygenLevel >= 100) ? 100 : GameManager.Instance._tank1OxygenLevel;
        GameManager.Instance._tank1OxygenLevel = (GameManager.Instance._tank1OxygenLevel <= 0) ? 0 : GameManager.Instance._tank1OxygenLevel;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _inRange = true;
        } 
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
           

            _inRange = false;
        }
    
    }


}
