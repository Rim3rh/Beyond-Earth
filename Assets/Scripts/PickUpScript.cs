using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class PickUpScript : MonoBehaviour
{
    public GameObject _pickUpSlot;
    public static bool _isHolding, _timerRuning;
    private float timer, timer2;
    private GameObject _itemTem;
    private PlayerInputActions playerInputActions;

    void Start()
    {
        timer2 = 0.5f;
        timer = 0f;
        _isHolding = false;
        playerInputActions = new PlayerInputActions();
        playerInputActions.PlayerMov.Interact.started += Interact_started;
        playerInputActions.PlayerMov.Enable();
    }

    private void Interact_started(InputAction.CallbackContext context)
    {
        if (_itemTem != null)
        {
            //Grab
            if (context.started && !_isHolding && timer <= 0)
            {
                if (GameManager.Instance._holdingSecondaryTank && _itemTem.CompareTag("Oxigeno2"))
                {
                }
                else
                {
                    StartCoroutine(Prueba());
                }
            }
            //Drop
            if (context.started && _isHolding && timer2 <= 0)
            {
                _itemTem = null;
                GameManager.Instance._item = _itemTem;
                _isHolding = false;
                timer = 0.5f;
                GameManager.Instance._speed = 6;
                GameManager.Instance.HudInteractOn();
                _timerRuning = true;
            }
        }
    }
    IEnumerator Prueba()
    {
        yield return null;
        if (!GameManager.Instance._disable)
        {
            _timerRuning = false;
            GameManager.Instance._item = _itemTem;
            _isHolding = true;
            timer2 = 0.5f;
            GameManager.Instance._speed = 6;
            GameManager.Instance.HudInteractOff();
        }
    }
    void Update()
    {
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
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 6 && !_isHolding)
        {
            _itemTem = other.gameObject;
            GameManager.Instance.HudInteractOn();
        }
        if (other.gameObject.CompareTag("Oxigeno") && !GameManager.Instance._holdingMainTank && !_isHolding)
        {
            _itemTem = other.gameObject;
            GameManager.Instance.HudInteractOn();
        }
        if (other.gameObject.CompareTag("Oxigeno2") && !GameManager.Instance._holdingSecondaryTank && !_isHolding)
        {
            _itemTem = other.gameObject;
            GameManager.Instance.HudInteractOn();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == 6 && !_isHolding)
        {
            _itemTem = null;
            GameManager.Instance.HudInteractOff();
        }
        if (other.gameObject.CompareTag("Oxigeno") && !GameManager.Instance._holdingMainTank && !_isHolding)
        {
            _itemTem = null;
            GameManager.Instance.HudInteractOff();
        }
        if (other.gameObject.CompareTag("Oxigeno2") && !GameManager.Instance._holdingSecondaryTank && !_isHolding)
        {
            _itemTem = null;
            GameManager.Instance.HudInteractOff();
        }
    }
}
