using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class UIManager : MonoBehaviour
{
   // public static UIManager Instance { get; private set; }

    [SerializeField] private Image _healthSlider, _oxygenSlider;
    public GameObject _interactCanvas, _digCanvas, _buildCanvas, _swapCanvas, _needPartsCanvas;

    public AudioSource _entrySound;

   [SerializeField] private GameObject  _optionsMenu, _optionsOptions, _pauseNormal, _exitButton, _resumeButton;




    public Slider _sfxSlider, _volSlider;

    private void Awake()
    {
        _sfxSlider.value = GameManager.Instance._sfxVolume;
        _volSlider.value = GameManager.Instance._musicVolume;
    }
    void Update()
    {
        GameManager.Instance._sfxVolume = _sfxSlider.value;
        GameManager.Instance._musicVolume = _volSlider.value;

        UpdateSliderValues();
        StatsDrop();
        SetMaxValues();
    }
    private void UpdateSliderValues()
    {
        //_foodSlider.fillAmount = GameManager.Instance._playerFood / 100;
        _healthSlider.fillAmount = GameManager.Instance._playerHealth / 100;
        _oxygenSlider.fillAmount = GameManager.Instance._playerOxygen / 100;
    }

    private void StatsDrop()
    {
        //FOOD
        //GameManager.Instance._playerFood -= Time.deltaTime * 2;

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





    public void EntrySound()
    {
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


}
