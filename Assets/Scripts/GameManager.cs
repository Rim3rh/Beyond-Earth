using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public float _playerHealth, _playerFood, _playerOxygen, _tank1OxygenLevel, _tank2OxygenLevel;

    public float timer, timer2;


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
        timer = 0.5f;
        timer2 = 0.5f;

        _tank1OxygenLevel = 100;
        _tank2OxygenLevel = 100;
        _playerHealth = 100;
        _playerFood = 100;
        _playerOxygen = 100;
    }

   

}
