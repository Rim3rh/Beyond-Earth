using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OxygenRecharge : MonoBehaviour
{
    private bool _tank1Chraging, _tank2Chraging;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (_tank1Chraging && !GameManager.Instance._holdingMainTank)
        {
          
            GameManager.Instance._tank1OxygenLevel += Time.deltaTime * 15;
        }
        if (_tank2Chraging && !GameManager.Instance._holdingSecondaryTank)
        {
            GameManager.Instance._tank2OxygenLevel += Time.deltaTime * 10;
        }

    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Oxigeno"))
        {
            _tank1Chraging = true;
        }
        if (other.CompareTag("Oxigeno2"))
        {
            _tank2Chraging = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Oxigeno"))
        {
            _tank1Chraging = false;
            
        }
        if (other.CompareTag("Oxigeno2"))
        {
            _tank2Chraging = false;
        }
    }
}
