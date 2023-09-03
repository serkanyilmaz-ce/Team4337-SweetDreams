using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public GameObject _quit_Button;
    public GameObject _howToPlayButton;
    private AudioSource[] _aSources;
    public GameObject howToPlayScreen;

    void Awake()
    {
        Time.timeScale = 0;
        howToPlayScreen.SetActive(true);
        _quit_Button.SetActive(false);
        _howToPlayButton.SetActive(false);
        _aSources = GetComponents<AudioSource>();
    }
    private void Start()
    {
        StartCoroutine(PlaySounds());
    }

    private IEnumerator PlaySounds()
    {
        _aSources[0].Play();
        yield return new WaitForSeconds(_aSources[0].clip.length);
        _aSources[1].Play();
    }

    public void close_button()
    {
        howToPlayScreen.SetActive(false);
        _quit_Button.SetActive(true);
        _howToPlayButton.SetActive(true);
        Time.timeScale = 1;
    }
    public void HowToPlayButton()
    {
        howToPlayScreen.SetActive(true);
        _quit_Button.SetActive(false);
        _howToPlayButton.SetActive(false);
        Time.timeScale = 0;
    }
    public void quit_button()
    {
        Application.Quit();
    }
}