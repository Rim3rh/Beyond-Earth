using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OxygenRecharge : MonoBehaviour
{
    private bool _tank1Chraging, _tank2Chraging;
    public GameObject _tank1;
    int _cont, _estado;
    public ParticleSystem _oxygenFinish;

    private GameObject _tempFood;

    public Material _state1, _state2, _state3;
    public GameObject _objeto;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        switch (_estado)
        {
            case 1:
                _objeto.GetComponent<MeshRenderer>().material = _state3;

                break;
            case 2:
                _objeto.GetComponent<MeshRenderer>().material = _state2;
                break;
            case 3:
                _objeto.GetComponent<MeshRenderer>().material = _state3;
                break;
        }


        if (_tank1Chraging && !GameManager.Instance._holdingFood)
        {
            if(_tempFood != null)
            {
                if (!GameManager.Instance._material)
                {
                    _estado = 2;
                }
                _tempFood.transform.position = new Vector3(-7.2f, 2.845f, 24.4f);
                _tempFood.transform.rotation = Quaternion.Euler(0f, -143.518f, 2.082f);
            }
            
            //GameManager.Instance._tank1OxygenLevel += Time.deltaTime * 15;
           // GameManager.Instance._oxygenCharging = true;
        }
        else
        {
            GameManager.Instance._oxygenCharging = false;
            if (!GameManager.Instance._material)
            {
                _estado = 3;
            }
           

        }




    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Oxigeno"))
        {
            _tank1Chraging = true;

            _tempFood = other.gameObject;
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

            _tempFood = other.gameObject;

        }
        if (other.CompareTag("Oxigeno2"))
        {
            _tank2Chraging = false;
        }
    }
}
