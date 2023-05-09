using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SalirDeCasaScript : MonoBehaviour
{
    
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

        yield return new WaitForSeconds(1);

    }




}
