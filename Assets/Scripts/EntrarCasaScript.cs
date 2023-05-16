using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class EntrarCasaScript : MonoBehaviour
{

    public Animator _fade;
    public GameObject _player;
    public Transform _houseEnter;
    public CinemachineVirtualCamera _cam;

    public GameObject _rocket1, _rocket2;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(EntrarCasa());
        }
    }

    private IEnumerator EntrarCasa()
    {
        if (GameManager.Instance._replaceWithGoodTank)
        {
            _rocket1.SetActive(true);
            _rocket2.SetActive(false);
            GameObject.FindGameObjectWithTag("RepairPart1").SetActive(false);
            GameObject.FindGameObjectWithTag("RepairPart2").SetActive(false);
            GameObject.FindGameObjectWithTag("RepairPart3").SetActive(false);
        }


        GameManager.Instance._canMove = false;
        _fade.Play("Fade");
        yield return new WaitForSeconds(0.5f);
        _player.transform.position = _houseEnter.transform.position;
        GameManager.Instance._insideHouse = true;
        yield return new WaitForSeconds(1f);
      //  _cam.m_XAxis.Value
        GameManager.Instance._canMove = true;


    }
}
