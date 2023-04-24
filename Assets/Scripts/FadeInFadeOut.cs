using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FadeInFadeOut : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            int sceneBuildIndex = SceneManager.GetActiveScene().buildIndex;

            if(sceneBuildIndex == 0)
            {
                SceneManager.LoadScene(1);
            }
            else
            {
                SceneManager.LoadScene(0);
            }
        }
    }

    IEnumerator ChangeToSceneB()
    {
        Animation.set
    }

    IEnumerator ChangeToSceneA()
    {

    }
}
