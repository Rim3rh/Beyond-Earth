using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarRotacion : MonoBehaviour
{
    float _rotationSpeed;
    void Start()
    {
        _rotationSpeed = 0.5f;
    }

    // Update is called once per frame
    void Update()
    {
        transform.eulerAngles = new Vector3(0, 0, transform.rotation.z + Time.deltaTime);
    }
}
