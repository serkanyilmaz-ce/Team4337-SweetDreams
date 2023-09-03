using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_MainMenu : MonoBehaviour
{
    private int _chosenIndex = 0;

    private int _bedCount;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void LeftArrow()
    {
        if (_chosenIndex - 1 < 0)
        {
            _chosenIndex = _bedCount-1;
        }
        PlayerPrefs.SetInt("ChosenBed", _chosenIndex);
    }
    private void RightArrow()
    {
        if (_chosenIndex + 1 >= _bedCount)
        {
            _chosenIndex = 0;
        }
        PlayerPrefs.SetInt("ChosenBed",_chosenIndex);
    }
}
