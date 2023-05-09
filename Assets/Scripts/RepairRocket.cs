using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class RepairRocket : MonoBehaviour
{
    private PlayerInputActions playerInputActions;

    public CinemachineVirtualCamera _cam;
    public ParticleSystem _particle;

    private GameObject _repairPart1, _repairPart2, _repairPart3;
    public bool _repairPartBool1, _repairPartBool2, _repairPartBool3;
    public bool _fixedPart1, _fixedPart2, _fixedPart3;

    int contador;
   // public GameObject _cam;

    void Awake()
    {
        playerInputActions = new PlayerInputActions();
        playerInputActions.PlayerMov.Enable();
        playerInputActions.PlayerMov.Interact.started += Interact_started;


        _fixedPart1 = false;
        _fixedPart2 = false;
        _fixedPart3 = false;
        _repairPartBool1 = false;
        _repairPartBool2 = false;
        _repairPartBool3 = false;

    }

    private void Interact_started(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        if (_repairPartBool1)
        {
            _fixedPart1 = true;
        }
        if (_repairPartBool2)
        {
            _fixedPart2 = true;
        }
        if (_repairPartBool3)
        {
            _fixedPart3 = true;
        }
    }

    void Update()
    {

        if (_fixedPart1 && !PickUpScript._isHolding)
        {
            
            if (contador <= 1)
            {
                StartCoroutine(ChangeCam());
                contador++;
            }
           

           
          
        }
        if (_fixedPart2 && !PickUpScript._isHolding)
        {
            Debug.Log("HOLA");
            _repairPart2.transform.position = new Vector3(10.68563f, 4.42374f, 47.02574f);
            _repairPart2.transform.rotation = Quaternion.Euler(-90, 0, 55.385f);
        }
        if (_fixedPart3 && !PickUpScript._isHolding)
        {

        }


    }

    private IEnumerator ChangeCam()
    {
        _cam.Priority = 40;

        yield return new WaitForSeconds(1.5f);
        _particle.Play();
        yield return new WaitForSeconds(0.75f);
        _repairPart1.transform.position = new Vector3(12.143f, 5.08f, 49.591f);
        _repairPart1.transform.rotation = Quaternion.Euler(-90, 0, 50);
        yield return new WaitForSeconds(1.5f);
        _cam.Priority = 10;
    }




    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("RepairPart1") )
        {
            _repairPartBool1 = true;
            _repairPart1 = other.gameObject;
        }
        if (other.CompareTag("RepairPart2"))
        {
            _repairPartBool2 = true;
            _repairPart2 = other.gameObject;
            GameManager.Instance._gear = true;
        }
        if (other.CompareTag("RepairPart3"))
        {
            _repairPartBool3 = true;
            _repairPart3 = other.gameObject;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("RepairPart1"))
        {
            _repairPartBool1 = false;
        }
        if (other.CompareTag("RepairPart2"))
        {
            _repairPartBool2 = false;
        }
        if (other.CompareTag("RepairPart3"))
        {
            _repairPartBool3 = false;
        }
    }
}
