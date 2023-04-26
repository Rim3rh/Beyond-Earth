using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodScript : MonoBehaviour
{
    public MeshRenderer _foodRender;
    [SerializeField] Color _myColor;
    [SerializeField] Color _myColor2;

    private float _cookingState;
    private PlayerInputActions playerInputActions;
    private bool _inRange;
    public bool _isCooked;
    private bool _cooking;
    void Start()
    {
        _cookingState = 0;

        playerInputActions = new PlayerInputActions();
        playerInputActions.PlayerMov.Interact.started += Interact_started;
        playerInputActions.PlayerMov.Enable();
    }


    private void Interact_started(UnityEngine.InputSystem.InputAction.CallbackContext context)
    {
        if (_isCooked && this.gameObject != null)
        {
            if(context.started && _inRange)
            {

                StartCoroutine(Destroy());
            }


        }
    }

    // Update is called once per frame
    void Update()
    {
        _foodRender.material.color = Color.Lerp(_myColor, _myColor2, _cookingState / 100);

        if (_cookingState >= 100) _isCooked = true;
            if (_cooking)
        {
            _cookingState += Time.deltaTime * 10;
        }


       
    }


    private IEnumerator Destroy()
    {
        GameManager.Instance._disable = true;
        GameManager.Instance.AddFood(70);
        yield return new WaitForSeconds(0.2f);
        GameManager.Instance._disable = false;
        playerInputActions.PlayerMov.Disable();
        Destroy(this.gameObject);
        
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Kitchen"))
        {
            _cooking = true;
        }
        if (other.CompareTag("Player"))
        {
            _inRange = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Kitchen"))
        {
            _cooking = false;
        }
        if (other.CompareTag("Player"))
        {
            _inRange = false;
        }
    }
}
