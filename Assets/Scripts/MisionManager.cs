using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MisionManager : MonoBehaviour
{
    public GameObject _toysArchivement;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(GameManager.Instance._easterEggCounter == 3)
        {
            Debug.Log("AHGFSDJKIASHDIPKUJAHBN");
            _toysArchivement.GetComponent<Animator>().Play("ToysArchivement");
        }
    }
}
