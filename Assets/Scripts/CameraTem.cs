using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTem : MonoBehaviour
{


    public GameObject _player;

    void Update()
    {
        this.transform.position = new Vector3(_player.transform.position.x, this.transform.position.y, _player.transform.position.z);
    }
  
}
