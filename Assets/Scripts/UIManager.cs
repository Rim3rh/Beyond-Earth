using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{

   
    [SerializeField] private Slider _foodSlider, _healthSlider, _oxygenSlider;
     private Button _addFood, _addOxygen;

    [SerializeField] private TextMeshProUGUI _tetx;
    [SerializeField] private TextMeshProUGUI _timeLeft;
    [SerializeField] private TextMeshProUGUI _timer;


    private float timer;
    

   
    void Start()
    {
        timer = 30f;
 
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance._playerHealth <= 0) SceneManager.LoadScene(1);
            
      
        







        timer -= Time.deltaTime;
        
        _tetx.text = GameManager.Instance._round.ToString();
        _timeLeft.text = Mathf.Round(timer).ToString();
        _timer.text = Mathf.Round(Time.time).ToString();
        if (timer <= 0)
        {
            GameManager.Instance._round++;
            timer = 30f;
        }


        UpdateSliderValues();
        StatsDrop();

    }
    private void UpdateSliderValues()
    {
        _foodSlider.value = GameManager.Instance._playerFood;
        _healthSlider.value = GameManager.Instance._playerHealth;
        _oxygenSlider.value = GameManager.Instance._playerOxygen;
    }

    private void StatsDrop()
    {
        SetMaxValues();

        
        //FOOD
        GameManager.Instance._playerFood -= Time.deltaTime * 2 * GameManager.Instance._round;

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

}
