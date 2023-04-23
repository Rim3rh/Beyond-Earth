using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OxygenTank : MonoBehaviour
{
    private bool _inRange;
    private bool _beingHeld;
    private bool _canCharge;

    public GameObject _oxygenSlot;

    void Start()
    {
        _beingHeld = false;
        _inRange = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (_inRange)
        {

            if (Input.GetKeyDown(KeyCode.E))
            {
                _beingHeld = true;
            }
            if (_beingHeld)
            {
                this.transform.position = _oxygenSlot.transform.position;
                if (Input.GetKeyDown(KeyCode.C))
                {
                    _beingHeld = false;
                }
            }

        }


        //if(_canCharge)
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _inRange = true;
        }

        if (other.CompareTag("OxygenRecharge"))
        {
            _canCharge = true;
        }


    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _inRange = false;
        }
        if (other.CompareTag("OxygenRecharge"))
        {
            _canCharge = false;
        }
    }

}
