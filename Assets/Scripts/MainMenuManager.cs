using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public GameObject _stars;

    public Animator _black;

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

}
