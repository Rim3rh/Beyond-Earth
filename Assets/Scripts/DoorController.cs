using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    int contador;
    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && contador <=0)
        {
            //LeanTween.rotateLocal(this.gameObject, new Vector3(0, 0, -110), 0.75f).setEaseOutBack();
            LeanTween.moveLocalX(this.gameObject, 5, 1f).setEaseOutBack();
            contador++;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
      
    }
}
