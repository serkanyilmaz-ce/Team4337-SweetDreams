using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject _character;
    public GameObject _openningScreen;
    public Image[] _loadingElements;
    private CharAutoMovement _charAutoMovement;
    public GameObject _buttonsPanel;

    void Start()
    {
        _charAutoMovement = _character.GetComponent<CharAutoMovement>();
        StartCoroutine(OpenGameScreen());
    }

    private IEnumerator OpenGameScreen()
    {
        var i = -1;

        while (++i < 10)
        {
            yield return new WaitForSeconds(0.5f);
            _loadingElements[i].enabled = true;
        }
        yield return new WaitForSeconds(1f);
        _openningScreen.SetActive(false);
        _buttonsPanel.SetActive(true);
        _charAutoMovement.enabled = true;
        GetComponents<AudioSource>()[0].Play();
    }
}