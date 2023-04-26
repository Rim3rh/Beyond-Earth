using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] _spawners;

    private int _temp;
    
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("InstanciateFood", 0, 5);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void InstanciateFood()
    {
        _temp = Random.Range(0, 4);
        Debug.Log(_temp);
        Instantiate(_spawners[8], _spawners[_temp].transform);
    }
}
