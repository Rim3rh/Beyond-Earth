using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OxygenTank : MonoBehaviour
{

    private bool _inRange;
   
   







    public GameObject _oxygenSlot;
    public GameObject _oxygenDrop;
    public GameObject _secondaryTank;



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

        if (GameManager.Instance._tank1OxygenLevel > 60 && GameManager.Instance._tank1OxygenLevel <= 100) _oxygenRender.material = _green;
        if (GameManager.Instance._tank1OxygenLevel > 30 && GameManager.Instance._tank1OxygenLevel < 60) _oxygenRender.material = _orange;
        if (GameManager.Instance._tank1OxygenLevel > 0 && GameManager.Instance._tank1OxygenLevel < 30) _oxygenRender.material = _red;

        if (CharacterController._holdingSecondaryTank)
        {
            GameManager.Instance.timer -= Time.deltaTime;
            if (_inRange)
            {
                if (Input.GetKeyDown(KeyCode.E) && GameManager.Instance.timer < 0)
                {
                    _secondaryTank.transform.position = _oxygenDrop.transform.position;
                    CharacterController._holdingMainTank = true;
                    CharacterController._holdingSecondaryTank = false;
                    GameManager.Instance.timer2 = 0.5f;
                }
            }
        }


        if (CharacterController._holdingMainTank)
        {


            this.transform.position = _oxygenSlot.transform.position;
            //oxygen level goes down
            GameManager.Instance._tank1OxygenLevel -= Time.deltaTime * 7;


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
