using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PreGameManager : MonoBehaviour
{


    public GameObject _logoFlorida;

    public Animator _animFlorida, _animLogo, _FADE;
    void Start()
    {
        StartCoroutine(PreGame());
    }

    // Update is called once per frame
    void Update()
    {
      //  LeanTween.moveY(this.gameObject, 50, 1f).setEaseOutBack();
    }

    private IEnumerator PreGame()
    {

        _FADE.Play("FADEIN");
         //Debug.Log("adsnifandio");
        yield return new WaitForSeconds(0.5f);
        _animFlorida.Play("LogoEntry");
        yield return new WaitForSeconds(3f);
        _animFlorida.Play("LogoExit");
        yield return new WaitForSeconds(0.1f);
        _animLogo.Play("FloridaEntry");
        yield return new WaitForSeconds(3f);
        _animLogo.Play("NuestroEntry");
        _FADE.Play("FADEOUT");
        
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(0);

    }
}
