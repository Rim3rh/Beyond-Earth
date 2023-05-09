using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepairPart2Rotation : MonoBehaviour
{
    public GameObject _gear1, _gear2;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (GameManager.Instance._gear)
        {
            _gear1.transform.Rotate(0, 0, 0.5f, Space.Self);
            _gear2.transform.Rotate(0, 0, -0.5f, Space.Self);
        }
      
    }

    
}
