using System;
using System.Collections;
using System.Collections.Generic;
using Beautify.Universal;
using UnityEngine;

public class CloseEye : MonoBehaviour
{
    // Start is called before the first frame update
    private void Start()
    {
        //BeautifySettings.Blink(3,0.9f);
    }

    // Update is called once per frame
    private void Update()
    {
       
    }

    private void BlinkOperation()
    {
         StartCoroutine(DelayCloseEye());
    }
    private static IEnumerator DelayCloseEye()
    {
        yield return new WaitForEndOfFrame();
    }
}
