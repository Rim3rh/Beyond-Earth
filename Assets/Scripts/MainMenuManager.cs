using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class MainMenuManager : MonoBehaviour
{
    public GameObject _stars;

    public Animator _black;

    public GameObject _mainMenu, _optionsMenu, _controls, _exit;

    public AudioSource _music, _buttonclick;

    public Slider _volSlider, _sfxSlider;
    


    public GameObject _play, _options;
    private void Awake()
    {
        EventSystem.current.SetSelectedGameObject(_play);
        _volSlider.value = 0.4f;
        _sfxSlider.value = 0.4f;
    }

    void Update()
    {
        GameManager.Instance._musicVolume = _volSlider.value;
        _music.volume = GameManager.Instance._musicVolume;

        GameManager.Instance._sfxVolume = _sfxSlider.value;


        _buttonclick.volume = GameManager.Instance._sfxVolume;


        _stars.transform.Rotate(0, 0, -0.3f * Time.deltaTime);
    }

    public void PlayGame()
    {
        _buttonclick.Play();
        StartCoroutine(Play());
    }


    public void ExitGame()
    {
        _buttonclick.Play();
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
        _buttonclick.Play();
        EventSystem.current.SetSelectedGameObject(null);
        _optionsMenu.SetActive(true);
        _mainMenu.SetActive(false);
        EventSystem.current.SetSelectedGameObject(_options);


        
    }
    public void OpenControls()
    {
        _buttonclick.Play();
        EventSystem.current.SetSelectedGameObject(null);
        _controls.SetActive(true);
        _optionsMenu.SetActive(false);
        EventSystem.current.SetSelectedGameObject(_exit);



    }
    public void CloseControls()
    {
        _buttonclick.Play();
        EventSystem.current.SetSelectedGameObject(null);
        _mainMenu.SetActive(true);
        _controls.SetActive(false);
        EventSystem.current.SetSelectedGameObject(_play);

    }
    public void CloseOptions()
    {
        _buttonclick.Play();
        EventSystem.current.SetSelectedGameObject(null);
        _mainMenu.SetActive(true);
        _optionsMenu.SetActive(false);
        EventSystem.current.SetSelectedGameObject(_play);
    }


}
