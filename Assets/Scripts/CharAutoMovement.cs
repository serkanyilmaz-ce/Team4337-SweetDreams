using System;
using System.Collections;
using System.Collections.Generic;
using Beautify.Universal;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;
public class CharAutoMovement : MonoBehaviour
{
    public GameObject []WPs;
    float _speed = 3f;
    private Animator _anim;
    void OnEnable()
    {
        _anim = GetComponent<Animator>();
    }
    public void StartGameStartCoroutine()
    {
        StartCoroutine(PlayScene());
    }
    private static void LoadScene()
    {
        SceneManager.LoadScene("Level_Dream_01");
    }
    private IEnumerator PlayScene()
    {
        yield return new WaitForSeconds(2f);
        _anim.SetBool("walking",true);
        transform.LookAt(WPs[0].transform.position);
        transform.DOMove(WPs[0].transform.position,2f);
        yield return new WaitForSeconds(2f);
        _anim.SetBool("walking",false);
        _anim.SetBool("climbing",true);
        transform.DOMove(WPs[1].transform.position,1f);
        yield return new WaitForSeconds(1f);
        _anim.SetBool("climbing",false);
        _anim.SetBool("resting",true);
        yield return new WaitForSeconds(2f);
        BeautifySettings.Blink(1f,1f);
        yield return new WaitForSeconds(1f);
        LoadScene();
    }
}
