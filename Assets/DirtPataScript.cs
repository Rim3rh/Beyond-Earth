using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirtPataScript : MonoBehaviour
{
    private PlayerInputActions playerInputActions;
    private bool _inRange;
    [SerializeField] private GameObject _pieza;
    void Start()
    {
        _inRange = false;
        playerInputActions = new PlayerInputActions();
        playerInputActions.PlayerMov.Enable();
        playerInputActions.PlayerMov.Interact.started += Interact_started;
    }
    private void Interact_started(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        if (_inRange && GameManager.Instance._holdingShovel)
        {
          //  Instantiate(_pieza, transform.position + new Vector3(0,10,0), Quaternion.identity;
            playerInputActions.PlayerMov.Disable();
            Destroy(gameObject);
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
