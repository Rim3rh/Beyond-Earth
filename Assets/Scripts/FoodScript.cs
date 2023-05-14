using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodScript : MonoBehaviour
{
   // public MeshRenderer _foodRender;
    [SerializeField] Color _myColor;
    [SerializeField] Color _myColor2;
    [SerializeField] ParticleSystem _kek;

    private float _cookingState;
    private PlayerInputActions playerInputActions;
    private bool _inRange;
    public bool _isCooked;
    private bool _cooking;
    int cont = 0;


    public Animator _KeepBreathign, _lestGetGoing, _plantFlag;

    public GameObject _interactHud;
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

        if (GameManager.Instance._FixedParts == 3 && cont < 1)
        {

            _lestGetGoing.Play("Exit");
            _plantFlag.Play("Entry");
            cont++;
        }


        // _foodRender.material.color = Color.Lerp(_myColor, _myColor2, _cookingState / 100);

        if (_cookingState >= 100)
        {
            _isCooked = true;
            
            if (cont < 1)
            {
                _kek.Play();
                cont++;
            }
        }
        

            if (_cooking)
            {

                _cookingState += Time.deltaTime * 10;
            
            }


       
    }


    private IEnumerator Destroy()
    {
        if(GameManager.Instance._skipFirstMision < 1)
        {
            _KeepBreathign.Play("Exit");
            _lestGetGoing.Play("Entry");
            GameManager.Instance._skipFirstMision++;
        }

        GameManager.Instance._disable = true;
        GameManager.Instance.AddOxygen(75);
        yield return new WaitForSeconds(0.2f);
        GameManager.Instance._disable = false;
        playerInputActions.PlayerMov.Disable();

        _interactHud.SetActive(false);
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
            GameManager.Instance._holdingFood = true;
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
            GameManager.Instance._holdingFood = false;
        }
    }
}
