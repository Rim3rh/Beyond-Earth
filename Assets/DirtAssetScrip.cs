using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirtAssetScrip : MonoBehaviour
{
    private PlayerInputActions playerInputActions;

    public GameObject _obj;

    void Start()
    {
        playerInputActions = new PlayerInputActions();
        playerInputActions.PlayerMov.Enable();
        playerInputActions.PlayerMov.Interact.started += Interact_started;
    }

    private void Interact_started(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {

        if(GameManager.Instance._insideDiggingHole && GameManager.Instance._holdingShovel)
        {
            Instantiate(_obj, new Vector3(0, 4, 0), Quaternion.Euler(-90, 0, 0));
            playerInputActions.PlayerMov.Disable();
            GameManager.Instance._insideDiggingHole = false;
            Destroy(this.gameObject);
        }


    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.Instance._insideDiggingHole = true;
        }
        
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.Instance._insideDiggingHole = false;
        }
    }
}
