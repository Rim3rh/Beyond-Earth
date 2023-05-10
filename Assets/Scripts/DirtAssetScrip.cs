using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirtAssetScrip : MonoBehaviour
{
    private PlayerInputActions playerInputActions;

    public GameObject _obj;
    private bool _inRange;

    void Start()
    {
        playerInputActions = new PlayerInputActions();
        playerInputActions.PlayerMov.Enable();
        playerInputActions.PlayerMov.Interact.started += Interact_started;
        _inRange = false;
    }

    private void Interact_started(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        
        if(GameManager.Instance._insideDiggingHole && GameManager.Instance._holdingShovel && _inRange)
        {
            //Debug.Log(gameObject.tag); 
            if (this.gameObject.CompareTag("RepairPart3"))
            {
                Instantiate(_obj, this.transform.position + new Vector3(0, 4, 0), Quaternion.Euler(-90, 0, 0));
            }
            else
            {
                Instantiate(_obj, this.transform.position + new Vector3(0, 0, 0), Quaternion.Euler(-90, 0, 0));
            }
            
            playerInputActions.PlayerMov.Disable();
            GameManager.Instance._insideDiggingHole = false;
            PickUpScript.timer2 = 0.5f;
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
            _inRange = true;
        }
        
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.Instance._insideDiggingHole = false;
            _inRange = false;
        }
    }
}
