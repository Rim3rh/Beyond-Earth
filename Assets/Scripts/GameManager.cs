using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public float _playerHealth, _playerFood, _playerOxygen, _tank1OxygenLevel, _tank2OxygenLevel;
    public float timer, timer2;
    
    public int _speed;
    public bool _holdingMainTank;
    public bool _gear;

    public bool _holdingShovel, _insideDiggingHole;

    public bool _holdingSecondaryTank;
    public GameObject _item;
    public Animator fadeAnim;
    public bool _disable;
    public float _timer;
    public int _easterEggCounter;

    public bool _canMove;


    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        if (Instance == null)
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
        _canMove = true;
        _gear = false;
        _disable = false;
        timer = 0.5f;
        timer2 = 0.5f;
        _speed = 4;
        _tank1OxygenLevel = 100;
        _tank2OxygenLevel = 0;
        _playerHealth = 100;
        _playerFood = 100;
        _playerOxygen = 100;
        _holdingSecondaryTank = false;
        _holdingMainTank = true;
        _holdingShovel = false;

        
    }






    

    public void AddFood(int value)
    {
        _playerFood += value;
    }
    public void AddOxygen(int value)
    {
        _playerOxygen += value;
    }

    
}
