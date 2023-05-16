using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.SceneManagement;

public class RepairRocket : MonoBehaviour
{
    private PlayerInputActions playerInputActions;

    public CinemachineVirtualCamera _cam, _cam2, _endCam;
    public ParticleSystem _particle;

    private GameObject _repairPart1, _repairPart2, _repairPart3;
    public bool _repairPartBool1, _repairPartBool2, _repairPartBool3;
    public bool _fixedPart1, _fixedPart2, _fixedPart3;

    int contador, contador2, contador3, cont4;


    public ParticleSystem _rocket;

    public GameObject _player;






    private bool _playInside;
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

        if (GameManager.Instance._canLeave && cont4 < 1)
        {
            //PLAY END ANIMATION

            StartCoroutine(LoadEndScene());
            cont4++;

        }


        if (Input.GetKeyDown(KeyCode.K))
        {
            StartCoroutine(LoadEndScene());
        }


        if (_fixedPart1 && !PickUpScript._isHolding)
        {
            
            if (contador < 1)
            {

                StartCoroutine(ChangeCam(_repairPart1, new Vector3(12.143f, 5.08f, 49.591f), new Vector3(-90, 0, 50)));
                contador++;
                GameManager.Instance._FixedParts++;
            }
           

           
          
        }
        if (_fixedPart2 && !PickUpScript._isHolding)
        {

            if(contador2 < 1)
            {
                StartCoroutine(ChangeCam2(_repairPart2, new Vector3(10.68563f, 4.42374f, 47.02574f), new Vector3(-90, 0, 55.385f)));
                contador2++;
                GameManager.Instance._FixedParts++;
            }
            
        }
        if (_fixedPart3 && !PickUpScript._isHolding)
        {
            if (contador3 < 1)
            {
                StartCoroutine(ChangeCam(_repairPart3, new Vector3(11.723f, 13.27719f, 47.584f), new Vector3(-90, 0, 0f)));
                contador3++;
                GameManager.Instance._FixedParts++;
            }
        }


    }

    private IEnumerator ChangeCam(GameObject name, Vector3 pos, Vector3 rot)
    {

        GameManager.Instance._canMove = false;
        _cam.Priority = 40;

        yield return new WaitForSeconds(1.5f);
        _particle.Play();
        yield return new WaitForSeconds(0.75f);
        name.transform.position = pos;
        name.transform.rotation = Quaternion.Euler(rot);
        yield return new WaitForSeconds(1.5f);
        _cam.Priority = 10;
        GameManager.Instance._canMove = true;
    }


    private IEnumerator ChangeCam2(GameObject name, Vector3 pos, Vector3 rot)
    {

        GameManager.Instance._canMove = false;
        _cam2.Priority = 40;

        yield return new WaitForSeconds(1.5f);
        _particle.Play();
        yield return new WaitForSeconds(0.75f);
        name.transform.position = pos;
        name.transform.rotation = Quaternion.Euler(rot);
        LeanTween.moveX(_cam2.gameObject, 9, 2f);
        yield return new WaitForSeconds(3f);
        _cam2.Priority = 10;
        GameManager.Instance._canMove = true;
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
          //  Debug.Log("LAÑSMJDPOANSFDJOIMANDS");
            _repairPartBool3 = true;
            _repairPart3 = other.gameObject;
        }



        if (other.CompareTag("Player"))
        {
            _playInside = true;
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





        if (other.CompareTag("Player"))
        {
            //LOAD END SCENE
            _playInside = false;
        }

  
    }



    private IEnumerator LoadEndScene()
    {
        _player.SetActive(false);
        _endCam.Priority = 100;
        yield return new WaitForSeconds(2);
        _rocket.Play();
        LeanTween.moveLocalY(this.gameObject, 50, 3f).setEaseInCirc();

        yield return new WaitForSeconds(4);
        SceneManager.LoadScene(3);



    }




}
