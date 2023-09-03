using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public AudioSource[] aSources;
    public GameObject howToPlayScreen;

    void Awake()
    {
        Time.timeScale = 0;
        howToPlayScreen.SetActive(true);
    }
    private void Start()
    {
        StartCoroutine(PlaySounds());
    }

    private IEnumerator PlaySounds()
    {
        aSources[0].Play();
        yield return new WaitForSeconds(aSources[0].clip.length);
        aSources[1].Play();
    }

    public void close_button()
    {
        howToPlayScreen.SetActive(false);
        Time.timeScale = 1;
    }
}