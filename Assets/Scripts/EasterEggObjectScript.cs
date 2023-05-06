using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EasterEggObjectScript : MonoBehaviour
{
    private bool _playerInRange;
    private PlayerInputActions _playerInputActions;
    void Start()
    {
        _playerInRange = false;
        _playerInputActions = new PlayerInputActions();
        _playerInputActions.PlayerMov.Interact.started += Interact_started;
        _playerInputActions.PlayerMov.Enable();
    }
    private void Interact_started(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        if (_playerInRange)
        {
            GameManager.Instance._easterEggCounter++;
            _playerInputActions.PlayerMov.Disable();
            Destroy(gameObject);

        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _playerInRange = true;   
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _playerInRange = false;
        }
    }
}
