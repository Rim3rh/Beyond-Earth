using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class HighScoreManager : MonoBehaviour
{

    public TextMeshProUGUI _1;
    // Start is called before the first frame update

    int cont;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            Application.Quit();
        }
        
        if(cont < 1)
        {
            GameManager.Instance._highScore1 = Mathf.Round(Time.time);
            cont++;

        }
        
        _1.text = GameManager.Instance._highScore1.ToString();



    }
}
