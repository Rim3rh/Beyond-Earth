using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OxygenTank : MonoBehaviour
{

    private bool _inRange;
    public GameObject _oxygenSlot, _secondaryTank, _oxygenDrop;
    public MeshRenderer _oxygenRender;
    [SerializeField] Color _myColor, _myColor2;
    private PlayerInputActions _playerInputActions;
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
        SetLimits();
        _oxygenRender.material.color = Color.Lerp(_myColor, _myColor2, GameManager.Instance._tank1OxygenLevel / 100);
        if (!PickUpScript._isHolding && GameManager.Instance._holdingSecondaryTank)
        {
            GameManager.Instance.timer -= Time.deltaTime;
        }
        if (GameManager.Instance._holdingMainTank)
        {
            this.transform.position = _oxygenSlot.transform.position;
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
