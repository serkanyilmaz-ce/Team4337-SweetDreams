using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{
    
    public GameObject Character;
    public GameObject howToPlayScreen;
    public GameObject howToPlayButton;
    public GameObject quitButton;
    public GameObject playButton;

    public void play_button()
    {
        quitButton.SetActive(false);
        playButton.SetActive(false);
        howToPlayScreen.SetActive(false);
        howToPlayButton.SetActive(false);
        Character.GetComponent<CharAutoMovement>().StartGameStartCoroutine();
    }
    public void HowToPlayButton()
    {
        howToPlayScreen.SetActive(true);
        quitButton.SetActive(false);
        playButton.SetActive(false);
        howToPlayButton.SetActive(false);
    }
    public void quit_button()
    {
        Application.Quit();
    }
    public void close_button()
    {
        howToPlayScreen.SetActive(false);
        quitButton.SetActive(true);
        playButton.SetActive(true);
    }
}
