using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketLeg : MonoBehaviour
{
    private bool _inRocket, _withPlayer;

    void Start()
    {
        _inRocket = false;
        _withPlayer = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(!_withPlayer && _inRocket)
        {
          
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _withPlayer = true;
        }
        if (other.CompareTag("Rocket"))
        {
            _inRocket = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _withPlayer = false;
        }
        if (other.CompareTag("Rocket"))
        {
            _inRocket = false;
        }
    }
}
