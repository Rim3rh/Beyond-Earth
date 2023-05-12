using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
   // public static UIManager Instance { get; private set; }

    [SerializeField] private Image _foodSlider, _healthSlider, _oxygenSlider;
    public GameObject _interactCanvas, _digCanvas, _buildCanvas, _swapCanvas, _needPartsCanvas;

    public AudioSource _entrySound;
    void Update()
    {
       
        UpdateSliderValues();
        StatsDrop();
        SetMaxValues();
    }
    private void UpdateSliderValues()
    {
        _foodSlider.fillAmount = GameManager.Instance._playerFood / 100;
        _healthSlider.fillAmount = GameManager.Instance._playerHealth / 100;
        _oxygenSlider.fillAmount = GameManager.Instance._playerOxygen / 100;
    }

    private void StatsDrop()
    {
        //FOOD
        //GameManager.Instance._playerFood -= Time.deltaTime * 2;

        //Oxygen
        GameManager.Instance._playerOxygen = (GameManager.Instance._holdingMainTank) ? GameManager.Instance._tank1OxygenLevel : GameManager.Instance._tank2OxygenLevel;


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




    public void HudInteractOn()
    {
        _interactCanvas.SetActive(true);
    }

    public void HudInteractOff()
    {
        _interactCanvas.SetActive(false);
    }
    public void HudBuildtOn()
    {
        _buildCanvas.SetActive(true);
    }

    public void HudBuildtOff()
    {  
        _buildCanvas.SetActive(false);
    }
    public void HudDigOn()
    {
        _digCanvas.SetActive(true);
    }

    public void HudDigOff()
    {
        _digCanvas.SetActive(false);
    }

    public void EntrySound()
    {
        _entrySound.Play();
    }

}
