using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class MainMenuManager : MonoBehaviour
{
    [SerializeField] private GameObject _stars;
    //Parent GameObject Menues
    [SerializeField] private GameObject _mainMenu, _optionsMenu, _controls;
    //Buttons
    [SerializeField] private GameObject _play, _options, _exit;
    public Animator _fadeAnim;
    public AudioSource _music, _buttonclick;
    public Slider _volSlider, _sfxSlider;
    private void Awake()
    {
        EventSystem.current.SetSelectedGameObject(_play);
        _volSlider.value = 0.4f;
        _sfxSlider.value = 0.4f;
    }
    void Update()
    {
        SetSliderValues();
        //BackGround Stars Rotation
        _stars.transform.Rotate(0, 0, -0.3f * Time.deltaTime);
    }
    private void SetSliderValues()
    {
        Debug.Log(GameManager.Instance._insideDiggingHole);
        Debug.Log(GameManager.Instance._musicVolume);
        Debug.Log(_volSlider.value);
      //  GameManager.Instance._musicVolume = _volSlider.value;
        
        
        _music.volume = GameManager.Instance._musicVolume;
        GameManager.Instance._sfxVolume = _sfxSlider.value;
        _buttonclick.volume = GameManager.Instance._sfxVolume;
    }
    public void PlayGame()
    {
        _buttonclick.Play();
        StartCoroutine(PlayGameC());
    }
    public void ExitGame()
    {
        _buttonclick.Play();
        Application.Quit();
    }
    private IEnumerator PlayGameC()
    {
        _fadeAnim.Play("FadeOut");
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
