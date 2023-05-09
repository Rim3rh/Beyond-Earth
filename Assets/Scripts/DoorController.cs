using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{

    void Start()
    {
        
    }

    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag.Equals("Player"))
        {
            LeanTween.rotateLocal(this.gameObject, new Vector3(0, 0, -110), 0.75f).setEaseOutBack();
        }
    }
}
