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
        GameManager.Instance._canMove = false;
        _fade.Play("Fade");
        yield return new WaitForSeconds(0.5f);
        _player.transform.position = _houseEnter.transform.position;
        yield return new WaitForSeconds(1f);
      //  _cam.m_XAxis.Value
        GameManager.Instance._canMove = true;


    }
}
