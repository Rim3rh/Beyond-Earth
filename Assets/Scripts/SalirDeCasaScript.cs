using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SalirDeCasaScript : MonoBehaviour
{
    public Animator _fade;
    public GameObject _player;
    public Transform _houseExit;
    void Start()
    {
        
    }

    
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(SalirCasa());
        }
    }

    private IEnumerator SalirCasa()
    {
        GameManager.Instance._canMove = false;
        _fade.Play("Fade");
        yield return new WaitForSeconds(1f);
        _player.transform.position = _houseExit.transform.position;
        yield return new WaitForSeconds(1.5f);
        
        GameManager.Instance._canMove = true;


    }




}
