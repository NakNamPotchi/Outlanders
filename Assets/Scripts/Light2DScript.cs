using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using Random = UnityEngine.Random;

public class Light2DScript : MonoBehaviour
{
    public GameObject LightComponent;
    public Light2D light;
    public float amplify;
 
    void Start()
    {
        LightComponent = GameObject.FindGameObjectWithTag("BookBloom");
        light = GetComponent<Light2D>();
    }

    void Update()
    {
        if (Mathf.Sin(Time.time) * amplify < 0.3f) 
        {
            light.intensity = Random.Range(0.3f, 0.5f);
        }
        else
        {
            light.intensity = Mathf.Sin(Time.time) * amplify;
        }
    }
}
