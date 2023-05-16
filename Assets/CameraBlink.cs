using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBlink : MonoBehaviour
{

    public GameObject _rec, _otro;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Rec());
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance._insideHouse)
        {
            _otro.SetActive(true);
        }
        else
        {
            _otro.SetActive(false);
        }
    }

    private IEnumerator Rec()
    {
        _rec.SetActive(false);
        yield return new WaitForSeconds(0.35f);
        _rec.SetActive(true);
        yield return new WaitForSeconds(0.35f);
        StartCoroutine(Rec());

    }
}
