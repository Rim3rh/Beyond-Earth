using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class PickUpScript : MonoBehaviour
{
    public GameObject _pickUpSlot;
    public static bool _isHolding, _timerRuning;
    public static float timer, timer2;
    private GameObject _itemTem;
    private PlayerInputActions playerInputActions;

    public GameObject _UiManager;

    public Animator _playerAnim;

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
            if (!_isHolding && timer <= 0 && !GameManager.Instance._oxygenCharging)
            {
                if (GameManager.Instance._holdingSecondaryTank && _itemTem.CompareTag("Oxigeno2"))
                {
                }
                else
                {
                    //_playerAnim.SetTrigger("COGER");
                    StartCoroutine(Prueba());
                }
            }
            //Drop
            if (_isHolding && timer2 <= 0 && !GameManager.Instance._insideDiggingHole)
            {

                if (_itemTem.CompareTag("Oxigeno"))
                {
                    GameManager.Instance._holdingFood = false;
                }
               // _playerAnim.SetTrigger("COGER");
                _itemTem = null;
                GameManager.Instance._item = _itemTem;
                _isHolding = false;
                timer = 0.5f;
                GameManager.Instance._speed = 6;
               
                _UiManager.GetComponent<UIManager>().HudInteractOn();
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
            GameManager.Instance._speed = 4;
            _UiManager.GetComponent<UIManager>().HudInteractOff();
        }
    }
    void Update()
    {
        if (_isHolding)
        {

            _playerAnim.SetBool("Grabing", true);


            if (GameManager.Instance._item.CompareTag("RepairPart1"))
            {
                GameManager.Instance._item.transform.position = new Vector3(_pickUpSlot.transform.position.x, _pickUpSlot.transform.position.y + 2, _pickUpSlot.transform.position.z);

            }
            else if(GameManager.Instance._item.CompareTag("RepairPart3"))
            {
                GameManager.Instance._item.transform.position = new Vector3(_pickUpSlot.transform.position.x, _pickUpSlot.transform.position.y + 2, _pickUpSlot.transform.position.z);
            }
            else
            {
                GameManager.Instance._item.transform.position = _pickUpSlot.transform.position;
                GameManager.Instance._item.transform.rotation = _pickUpSlot.transform.rotation;
            }
            timer2 -= Time.deltaTime;
        }
        else
        {
            _playerAnim.SetBool("Grabing", false);
        }



        if (_timerRuning)
        {
            timer -= Time.deltaTime;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        HudsEnter(other);
        if (other.gameObject.layer == 6 && !_isHolding)
        {
            _itemTem = other.gameObject;
        }
        if (other.gameObject.CompareTag("Oxigeno") && !GameManager.Instance._holdingMainTank && !_isHolding)
        {
            _itemTem = other.gameObject;
        }
        if (other.gameObject.CompareTag("Oxigeno2") && !GameManager.Instance._holdingSecondaryTank && !_isHolding)
        {
            _itemTem = other.gameObject;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        HudsExit(other);
        if (other.gameObject.layer == 6 && !_isHolding)
        {
            _itemTem = null;
        }
        if (other.gameObject.CompareTag("Oxigeno") && !GameManager.Instance._holdingMainTank && !_isHolding)
        {
            _itemTem = null;
        }
        if (other.gameObject.CompareTag("Oxigeno2") && !GameManager.Instance._holdingSecondaryTank && !_isHolding)
        {
            _itemTem = null;
        }




    }

    
    private void HudsEnter(Collider other)
    {
        if (other.gameObject.layer == 6 && !_isHolding)
        {
            _UiManager.GetComponent<UIManager>().HudInteractOn();
        }
        if (other.gameObject.CompareTag("Oxigeno") && !GameManager.Instance._holdingMainTank && !_isHolding)
        {
            _UiManager.GetComponent<UIManager>().HudInteractOn();
        }
        if (other.gameObject.CompareTag("Oxigeno2") && !GameManager.Instance._holdingSecondaryTank && !_isHolding)
        {
            _UiManager.GetComponent<UIManager>().HudInteractOn();
        }
        //WHEN U ENTER THE ROCKET
        if (other.gameObject.CompareTag("Rocket"))
        {
            _UiManager.GetComponent<UIManager>().HudBuildtOn();
        }
    }
    private void HudsExit(Collider other)
    {
        //WHEN U ENTER THE ROCKET
        if (other.gameObject.CompareTag("Rocket"))
        {
            _UiManager.GetComponent<UIManager>().HudBuildtOff();
        }


        if (other.gameObject.layer == 6 && !_isHolding)
        {
            _UiManager.GetComponent<UIManager>().HudInteractOff();
        }
        if (other.gameObject.CompareTag("Oxigeno") && !GameManager.Instance._holdingMainTank && !_isHolding)
        {
            _UiManager.GetComponent<UIManager>().HudInteractOff();
        }
        if (other.gameObject.CompareTag("Oxigeno2") && !GameManager.Instance._holdingSecondaryTank && !_isHolding)
        {
            _UiManager.GetComponent<UIManager>().HudInteractOff();
        }
    }
    
}
