using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OxygenTankReplacement : MonoBehaviour
{
    //ESTE SCRIP ES PARA COGEER EL SECUNDARIO
    private bool _inRange;



    public GameObject _oxygenSlot;
    public GameObject _oxygenDrop;
    public GameObject _mainTank;


    public MeshRenderer _oxygenRender;
    [SerializeField] Color _myColor;
    [SerializeField] Color _myColor2;
    private PlayerInputActions _playerInputActions;


    void Start()
    {
        _playerInputActions = new PlayerInputActions();
        _playerInputActions.PlayerMov.ChangeTank.started += ChangeTank_started;
        _playerInputActions.PlayerMov.Enable();



        _oxygenRender = GetComponent<MeshRenderer>();
        _inRange = false;
    }

    private void ChangeTank_started(UnityEngine.InputSystem.InputAction.CallbackContext context)
    {
        if (!PickUpScript._isHolding && GameManager.Instance._holdingMainTank)
        {
            GameManager.Instance.timer2 -= Time.deltaTime;
            if (_inRange)
            {
                if (context.started && GameManager.Instance.timer2 < 0)
                {
                    _mainTank.transform.position = _oxygenDrop.transform.position;
                    GameManager.Instance._holdingSecondaryTank = true;
                    GameManager.Instance._holdingMainTank = false;
                    GameManager.Instance.timer = 0.5f;
                }
            }
        }
    }

    



    void Update()
    {
        //Debug.Log(GameManager.Instance._item);
        SetLimits();

        _oxygenRender.material.color = Color.Lerp(_myColor, _myColor2, GameManager.Instance._tank2OxygenLevel / 100);
           //Lo explico xq al igual en otro momento ns q he hecho, le digo aqui q puede cambiar de tanke, si el item es igual a null o si no es igual a oxigeno, ya que
           //si lo fuese sinificaria q lo esta sujetando
        if (!PickUpScript._isHolding && GameManager.Instance._holdingMainTank)
        {
            GameManager.Instance.timer2 -= Time.deltaTime;
        }

        if (GameManager.Instance._holdingSecondaryTank)
        {
            this.transform.position = _oxygenSlot.transform.position;
            //oxygen level goes down
            GameManager.Instance._tank2OxygenLevel -= Time.deltaTime * 2;
        }


    }


    private void SetLimits()
    {
        GameManager.Instance._tank2OxygenLevel = (GameManager.Instance._tank2OxygenLevel >= 100) ? 100 : GameManager.Instance._tank2OxygenLevel;

        GameManager.Instance._tank2OxygenLevel = (GameManager.Instance._tank2OxygenLevel <= 0) ? 0 : GameManager.Instance._tank2OxygenLevel;
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
