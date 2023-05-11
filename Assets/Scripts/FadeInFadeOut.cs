using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FadeInFadeOut : MonoBehaviour
{
    //public Animator fadeAnim;
    // Start is called before the first frame update
    int cont;
    public Animator fadeAnim;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance._playerHealth <= 0)
        {
            if(cont <= 0)
            {
                StartCoroutine(ChangeToGameOver());
                cont++;
            }
        }
    }
    
    IEnumerator ChangeToGameOver()
    {
        fadeAnim.Play("Fade");
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(2);
    }
 
}
