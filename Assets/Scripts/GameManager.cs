using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public int _playerHealth, _playerHunger, _playerOxygen;


    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Debug.Log("Hay mas de un GameManager");
        }
    }
    void Start()
    {
        _playerHealth = 100;
        _playerHunger = 100;
        _playerOxygen = 100;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
