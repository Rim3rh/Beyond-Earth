using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OxygenTankReplacement : MonoBehaviour
{

    private bool _inRange;









    public GameObject _oxygenSlot;
    public GameObject _oxygenDrop;
    public GameObject _mainTank;


    public Renderer _oxygenRender;
    public Material _green;
    public Material _red;
    public Material _orange;


    

    void Start()
    {
         
        _inRange = false;
    }


    void Update()
    {
        

        if (GameManager.Instance._tank2OxygenLevel > 60 && GameManager.Instance._tank2OxygenLevel <= 100) _oxygenRender.material = _green;
        if (GameManager.Instance._tank2OxygenLevel > 30 && GameManager.Instance._tank2OxygenLevel < 60) _oxygenRender.material = _orange;
        if (GameManager.Instance._tank2OxygenLevel > 0 && GameManager.Instance._tank2OxygenLevel < 30) _oxygenRender.material = _red;

        if (CharacterController._holdingMainTank)
        {
            GameManager.Instance.timer2 -= Time.deltaTime;
            if (_inRange)
            {
               

                if (Input.GetKeyDown(KeyCode.E) && GameManager.Instance.timer2 < 0)
                {
                    _mainTank.transform.position = _oxygenDrop.transform.position;
                    CharacterController._holdingSecondaryTank = true;
                    CharacterController._holdingMainTank = false;
                    GameManager.Instance.timer = 0.5f;
                    
                }
            }


        }

        if (CharacterController._holdingSecondaryTank)
        {
            this.transform.position = _oxygenSlot.transform.position;
            //oxygen level goes down
            GameManager.Instance._tank2OxygenLevel -= Time.deltaTime * 7;
        }


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
