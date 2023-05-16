using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlagMission : MonoBehaviour
{
    private bool _ableToDrop;
    private bool _placed;
    private PlayerInputActions playerInputActions;

    public GameObject _flag;



    int cont;

    void Start()
    {
        playerInputActions = new PlayerInputActions();
        playerInputActions.PlayerMov.Enable();
        playerInputActions.PlayerMov.Interact.started += Interact_started;
    }

    private void Interact_started(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {

        if (_ableToDrop)
        {
            _placed = true;
        }

    }

    void Update()
    {
        if (_placed)
        {


            GameManager.Instance._flagPlaced = true;

            _flag.transform.position = new Vector3(1.32f, 3.57f, 37.80f);
            
            _flag.transform.rotation = Quaternion.Euler(-90f, 0f, 42.24f);
            GameManager.Instance._canLeave = true;
            
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && GameManager.Instance._holdingFlag)
        {
            _ableToDrop = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") && GameManager.Instance._holdingFlag)
        {
            _ableToDrop = false;
        }
    }




 
}
