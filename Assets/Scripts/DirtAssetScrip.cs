using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirtAssetScrip : MonoBehaviour
{
    private PlayerInputActions playerInputActions;

    public GameObject _obj;
    private bool _inRange;


    public MeshFilter _3, _2, _1,_current;
    private int _dirtCounter;
    float _dirtTimer;
    public ParticleSystem _paticles;
    public GameObject _collider;

    public AudioSource _cabar1, _cabar2, _cabar3;

    void Start()
    {
        _current = GetComponent<MeshFilter>();
        _dirtCounter = 3;
        playerInputActions = new PlayerInputActions();
        playerInputActions.PlayerMov.Enable();
        playerInputActions.PlayerMov.Interact.started += Interact_started;
        _inRange = false;
    }

    private void Interact_started(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
       



        if(GameManager.Instance._insideDiggingHole && GameManager.Instance._holdingShovel && _inRange)
        {
            
           

            switch (_dirtCounter)
            {
                case 3:
                    if (_dirtTimer < 0f)
                    {
                        // Debug.Log("goasl"); 
                        _dirtCounter--;
                        _dirtTimer = 0.5f;
                        _paticles.Play();
                        _cabar3.Play();
                    }

                    break;

                case 2:
                    if (_dirtTimer < 0f)
                    {
                        // Debug.Log("goasl"); 
                        _dirtCounter--;
                        _dirtTimer = 0.5f;
                        _paticles.Play();
                        _cabar2.Play();
                    }

                    break;
                case 1:
                    if (_dirtTimer < 0f)
                    {
                        // Debug.Log("goasl"); 
                        _dirtCounter--;
                        _dirtTimer = 0.5f;
                        _paticles.Play();
                        _cabar1.Play();
                    }

                    break;


            }
            

            if(_dirtCounter < 1)
            {
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
                _collider.SetActive(false);
                Destroy(this.gameObject);
            }
           
        }


    }

    // Update is called once per frame
    void Update()
    {
        _dirtTimer -= Time.deltaTime;
        switch (_dirtCounter)
        {

            case 3:
                _current.sharedMesh = Resources.Load<Mesh>("ASSETMonton_A");



                break;

            case 2:
                _current.sharedMesh = Resources.Load<Mesh>("ASSETMonton_B");

                break;

            case 1:

                _current.sharedMesh = Resources.Load<Mesh>("ASSETMonton_C");

                break;



        }
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
