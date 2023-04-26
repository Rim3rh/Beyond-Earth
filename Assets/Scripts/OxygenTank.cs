using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OxygenTank : MonoBehaviour
{

    private bool _inRange;
   
   







    public GameObject _oxygenSlot;
    public GameObject _oxygenDrop;
    public GameObject _secondaryTank;



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
        SetLimits();
        //Debug.Log(GameManager.Instance._tank1OxygenLevel);
        _oxygenRender.material.color = Color.Lerp(_myColor, _myColor2, GameManager.Instance._tank1OxygenLevel / 100);


        if (!CharacterController._isHolding && GameManager.Instance._holdingSecondaryTank && (GameManager.Instance._item == null || !GameManager.Instance._item.CompareTag("Oxigeno")))
        {
            GameManager.Instance.timer -= Time.deltaTime;
            if (_inRange)
            {
                if (Input.GetKeyDown(KeyCode.E) && GameManager.Instance.timer < 0)
                {
                    _secondaryTank.transform.position = _oxygenDrop.transform.position;
                    GameManager.Instance._holdingMainTank = true;
                    GameManager.Instance._holdingSecondaryTank = false;
                    GameManager.Instance.timer2 = 0.5f;
                }
            } 
        }


        if (GameManager.Instance._holdingMainTank)
        {


            this.transform.position = _oxygenSlot.transform.position;
            //oxygen level goes down
            GameManager.Instance._tank1OxygenLevel -= Time.deltaTime * 2 * GameManager.Instance._round;


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
