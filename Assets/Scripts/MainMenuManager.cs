using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;


public class MainMenuManager : MonoBehaviour
{
    public GameObject _stars;

    public Animator _black;

    public GameObject _mainMenu, _optionsMenu;



    public GameObject _play, _options;
    private void Start()
    {
        EventSystem.current.SetSelectedGameObject(_play);
    }

    // Update is called once per frame
    void Update()
    {
        _stars.transform.Rotate(0, 0, -0.3f * Time.deltaTime);
    }

    public void PlayGame()
    {
        StartCoroutine(Play());
    }


    public void ExitGame()
    {
        Application.Quit();
    }


    public IEnumerator Play()
    {
        _black.Play("FadeOut");
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(1);
    }
    public void OpenOptions()
    {
        EventSystem.current.SetSelectedGameObject(null);
        _optionsMenu.SetActive(true);
        _mainMenu.SetActive(false);
        EventSystem.current.SetSelectedGameObject(_options);



    }
    public void CloseOptions()
    {
        EventSystem.current.SetSelectedGameObject(null);
        _mainMenu.SetActive(true);
        _optionsMenu.SetActive(false);
        EventSystem.current.SetSelectedGameObject(_play);
    }


}
