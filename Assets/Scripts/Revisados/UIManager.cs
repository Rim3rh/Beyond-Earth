using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class UIManager : MonoBehaviour
{
    private PlayerInputActions playerInputActions;

    [SerializeField] private GameObject _recHud, _parentRecGameobject;

    [SerializeField] private GameObject _interactCanvas, _digCanvas, _buildCanvas, _swapCanvas, _needPartsCanvas;
    public AudioSource _entrySound;
    //Buttons
    [SerializeField] private GameObject  _optionsMenu, _optionsOptions, _pauseNormal, _exitButton, _resumeButton;
    //Sliders
    [SerializeField] private Slider _sfxSlider, _volSlider;
    [SerializeField] private Image _healthSlider, _oxygenSlider;

    private void Awake()
    {
        _sfxSlider.value = GameManager.Instance._sfxVolume;
        _volSlider.value = GameManager.Instance._musicVolume;
        playerInputActions = new PlayerInputActions();
        playerInputActions.PlayerMov.PAUSE.Enable();
        playerInputActions.PlayerMov.PAUSE.started += PAUSE_started;
        StartCoroutine(Rec());
    }

    private void PAUSE_started(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        //This will run when you hit the PAUSE button;
        OpenCloseMenu();
    }

    void Update()
    {
        UpdateSliderValues();
        StatsDrop();
        SetMaxValues();
        ActivateInsideCam();
    }

    private IEnumerator Rec()
    {
        _recHud.SetActive(false);
        yield return new WaitForSeconds(0.35f);
        _recHud.SetActive(true);
        yield return new WaitForSeconds(0.35f);
        StartCoroutine(Rec());
    }
    private void UpdateSliderValues()
    {
        _healthSlider.fillAmount = GameManager.Instance._playerHealth / 100;
        _oxygenSlider.fillAmount = GameManager.Instance._playerOxygen / 100;
        GameManager.Instance._sfxVolume = _sfxSlider.value;
        GameManager.Instance._musicVolume = _volSlider.value;
    }
    private void ActivateInsideCam()
    {
        if (GameManager.Instance._insideHouse)
        {
            _parentRecGameobject.SetActive(true);
        }
        else
        {
            _parentRecGameobject.SetActive(false);
        }
    }

    private void StatsDrop()
    {
        //Oxygen
        GameManager.Instance._playerOxygen -= Time.deltaTime * 1.5f;
        //Health
        if (GameManager.Instance._playerFood <= 0 && GameManager.Instance._playerOxygen <= 0)
        {
            GameManager.Instance._playerHealth -= Time.deltaTime * 6;
        }
        if (GameManager.Instance._playerFood <= 0 && GameManager.Instance._playerOxygen >= 0)
        {
            GameManager.Instance._playerHealth -= Time.deltaTime * 2;
        }
        if (GameManager.Instance._playerFood >= 0 && GameManager.Instance._playerOxygen <= 0)
        {
            GameManager.Instance._playerHealth -= Time.deltaTime * 4;
        }
    }
    private void SetMaxValues()
    {
        //Set food to 100 if food is over 100
        GameManager.Instance._playerFood = (GameManager.Instance._playerFood >= 100) ? 100 : GameManager.Instance._playerFood;
        //Set food to 0 if food is under 0
        GameManager.Instance._playerFood = (GameManager.Instance._playerFood <= 0) ? 0 : GameManager.Instance._playerFood;
        //Set health to 100 if health is over 100
        GameManager.Instance._playerHealth = (GameManager.Instance._playerHealth >= 100) ? 100 : GameManager.Instance._playerHealth;
        //Set health to 0 if health is under 0
        GameManager.Instance._playerHealth = (GameManager.Instance._playerHealth <= 0) ? 0 : GameManager.Instance._playerHealth;
        //Set Oxygen to 100 if oxygen is over 100
        GameManager.Instance._playerOxygen = (GameManager.Instance._playerOxygen >= 100) ? 100 : GameManager.Instance._playerOxygen;
        //Set Oxygen to 0 if Oxygen is under 0
        GameManager.Instance._playerOxygen = (GameManager.Instance._playerOxygen <= 0) ? 0 : GameManager.Instance._playerOxygen;
    }
    private void EntrySound()
    {
        //Sound Played when menu button clicled
        _entrySound.Play();
    }
    public void ResumeGame()
    {
        EntrySound();
        Time.timeScale = 1f;
        _optionsMenu.SetActive(false);
        GameManager.Instance._openedMenu = false;
    }
    public void OpenOptions()
    {
        EntrySound();
        _optionsOptions.SetActive(true);
        _pauseNormal.SetActive(false);
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(_exitButton);
    }
    public void CloseOptions()
    {
        EntrySound();
        _optionsOptions.SetActive(false);
        _pauseNormal.SetActive(true);
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(_resumeButton);
    }
    public void GoToMainMenu()
    {
        EntrySound();
        SceneManager.LoadScene(4);
    }
    private void OpenCloseMenu()
    {
        if (GameManager.Instance._openedMenu)
        {
            EventSystem.current.SetSelectedGameObject(null);
            Time.timeScale = 1f;
            _optionsMenu.SetActive(false);
            GameManager.Instance._openedMenu = false;
        }else
        {
            EventSystem.current.SetSelectedGameObject(null);
            EventSystem.current.SetSelectedGameObject(_resumeButton);
            _optionsMenu.SetActive(true);
            Time.timeScale = 0f;
            GameManager.Instance._openedMenu = true;
        }
    }
}
