using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using Random = UnityEngine.Random;

public class Light2DOther : MonoBehaviour
{
    public Light2D lightobject;
 
    void Start()
    {
        lightobject = GetComponent<Light2D>();
        StartCoroutine(ExecuteAfterTime(0.5f));
    }

    IEnumerator ExecuteAfterTime(float time)
    {
        yield return new WaitForSeconds(time);
        lightobject.enabled = true;
    }

    public void ClickPortal() {
        StartCoroutine(GameStageMap(0.4f));
    }

    IEnumerator GameStageMap(float time)
    {
        yield return new WaitForSeconds(time);
        lightobject.enabled = false;
    }
}
