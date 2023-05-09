using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public GameObject _stars;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _stars.transform.Rotate(0, 0, -0.3f * Time.deltaTime);
    }

    public void PlayGame()
    {
        SceneManager.LoadScene(1);
    }
    public void ExitGame()
    {
        Application.Quit();
    }


}
