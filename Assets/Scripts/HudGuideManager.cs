using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HudGuideManager : MonoBehaviour
{
    public GameObject _interact, _repair, _dig, _needParts, _consume;
    private PlayerInputActions playerInputActions;
    private bool _holding, _consumeB, _ableToBuild;

    void Start()
    {
        playerInputActions = new PlayerInputActions();
        playerInputActions.PlayerMov.Interact.started += Interact_started;
        playerInputActions.PlayerMov.ChangeTank.started += ChangeTank_started;
        playerInputActions.PlayerMov.Enable();

    }

    private void ChangeTank_started(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        if (_consumeB)
        {
            _consume.SetActive(false);
            _consumeB = false;
        }

        if (_ableToBuild)
        {
            _interact.SetActive(false);
            _repair.SetActive(false);
        }
    }

    private void Interact_started(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Cohete"))
        {
            if (GameManager.Instance._holdingRepairPart)
            {
                _repair.SetActive(true);
                _interact.SetActive(false);
                _ableToBuild = true;
            }
            else
            {
                _needParts.SetActive(true);
            }
        }


        if (other.CompareTag("Oxigeno") || other.CompareTag("Shovel") || other.CompareTag("RepairPart1") || other.CompareTag("RepairPart2") || other.CompareTag("RepairPart3") || other.CompareTag("Flag"))
        {
            _interact.SetActive(true);
        }

        if (other.CompareTag("Empty"))
        {
            _interact.SetActive(false);
        }

        if (other.CompareTag("Consume"))
        {
            _interact.SetActive(false);
            _consume.SetActive(true);
            _consumeB = true;
        }


        if (other.CompareTag("Dirt") && GameManager.Instance._holdingShovel)
        {
            _interact.SetActive(false);
            _dig.SetActive(true);
            //  _consumeB = true;

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Cohete"))
        {
            _repair.SetActive(false);
            _ableToBuild = false;
            _needParts.SetActive(false);
            if (GameManager.Instance._holdingRepairPart)
            {
               
            }
            else
            {
                
            }
        }

        if (other.CompareTag("Oxigeno") || other.CompareTag("Shovel") || other.CompareTag("RepairPart1") || other.CompareTag("RepairPart2") || other.CompareTag("RepairPart3") || other.CompareTag("Flag"))
        {
            _interact.SetActive(false);
        }

        if (other.CompareTag("Consume"))
        {
            _consumeB = false;
            _consume.SetActive(false);
        }




        if (other.CompareTag("Dirt"))
        {
          //  _interact.SetActive(false);
            _dig.SetActive(false);
            //  _consumeB = true;

            if (GameManager.Instance._holdingShovel)
            {
                _interact.SetActive(false);
            }
        }
    }
}
