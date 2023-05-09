using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class InsideHouse : MonoBehaviour
{

    public CinemachineVirtualCamera _cam;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(GameManager.Instance._insideHouse)
        {
            _cam.Priority = 80;
        }
        if (!GameManager.Instance._insideHouse)
        {
            _cam.Priority = 10;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.Instance._insideHouse = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.Instance._insideHouse = false;
        }
    }
}
