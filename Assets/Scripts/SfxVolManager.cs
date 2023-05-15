using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SfxVolManager : MonoBehaviour
{
    [SerializeField] private AudioSource _cabar1, _cabar2, _cabar3, _OnClick;



    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _cabar1.volume = GameManager.Instance._sfxVolume;
        _cabar2.volume = GameManager.Instance._sfxVolume;
        _cabar3.volume = GameManager.Instance._sfxVolume;
        _OnClick.volume = GameManager.Instance._sfxVolume;



    }
}
