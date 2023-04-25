using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OxygenTankReplacement : MonoBehaviour
{

    private bool _inRange;



    public GameObject _oxygenSlot;
    public GameObject _oxygenDrop;
    public GameObject _mainTank;


    public MeshRenderer _oxygenRender;
    [SerializeField] Color _myColor;
    [SerializeField] Color _myColor2;


    void Start()
    {
        _oxygenRender = GetComponent<MeshRenderer>();
        _inRange = false;
    }


    void Update()
    {
        Debug.Log(GameManager.Instance._item);
        SetLimits();

        _oxygenRender.material.color = Color.Lerp(_myColor, _myColor2, GameManager.Instance._tank2OxygenLevel / 100);
           //Lo explico xq al igual en otro momento ns q he hecho, le digo aqui q puede cambiar de tanke, si el item es igual a null o si no es igual a oxigeno, ya que
           //si lo fuese sinificaria q lo esta sujetando
        if (GameManager.Instance._holdingMainTank &&  (GameManager.Instance._item == null || !GameManager.Instance._item.CompareTag("Oxigeno2")))
        {
            

            GameManager.Instance.timer2 -= Time.deltaTime;
            if (_inRange)
            {
               

                if (Input.GetKeyDown(KeyCode.E) && GameManager.Instance.timer2 < 0)
                {
                    _mainTank.transform.position = _oxygenDrop.transform.position;
                    GameManager.Instance._holdingSecondaryTank = true;
                    GameManager.Instance._holdingMainTank = false;
                    GameManager.Instance.timer = 0.5f;
                    
                }
            }


        }

        if (GameManager.Instance._holdingSecondaryTank)
        {
            this.transform.position = _oxygenSlot.transform.position;
            //oxygen level goes down
            GameManager.Instance._tank2OxygenLevel -= Time.deltaTime * 7;
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
