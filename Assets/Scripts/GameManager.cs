using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public float _playerHealth, _playerFood, _playerOxygen, _tank1OxygenLevel, _tank2OxygenLevel;

    private PlayerInputActions playerInputActions;

    public float timer, timer2;
    public GameObject _interactCanvas;
    public int _speed;

    public Vector2 _moveInput;


    private void Awake()
    {
        playerInputActions = new PlayerInputActions();

        playerInputActions.Enable();
       // playerInputActions.PlayerMov.Interact.started += Interact;

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
        timer = 0.5f;
        timer2 = 0.5f;
        _speed = 10;
        _tank1OxygenLevel = 100;
        _tank2OxygenLevel = 100;
        _playerHealth = 100;
        _playerFood = 100;
        _playerOxygen = 100;

        _interactCanvas.SetActive(false);
    }

   


    public void HudInteractOn()
    {
        _interactCanvas.SetActive(true);
    }

    public void HudInteractOff()
    {
        _interactCanvas.SetActive(false);
    }

    private void Update()
    {
        _moveInput = playerInputActions.PlayerMov.Movement.ReadValue<Vector2>();
    }
}
