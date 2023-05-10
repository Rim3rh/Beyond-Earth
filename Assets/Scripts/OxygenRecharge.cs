using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OxygenRecharge : MonoBehaviour
{
    private bool _tank1Chraging, _tank2Chraging;
    public GameObject _tank1, _tank2;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (_tank1Chraging && !GameManager.Instance._holdingMainTank)
        {


            _tank1.transform.position = new Vector3(-7.479f, 2.934f, 23.775f);
            _tank1.transform.rotation = Quaternion.Euler(83.992f, -143.518f, 2.082f);
            GameManager.Instance._tank1OxygenLevel += Time.deltaTime * 15;
        }
        if (_tank2Chraging && !GameManager.Instance._holdingSecondaryTank)
        {
            _tank2.transform.position = new Vector3(-7.479f, 2.934f, 23.775f);
            _tank2.transform.rotation = Quaternion.Euler(83.992f, -143.518f, 2.082f);
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
