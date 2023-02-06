using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
using Random = UnityEngine.Random;

public class DynamicBloom : MonoBehaviour
{
    private PostProcessVolume volume;
    private Bloom bloom;
    public float amplify;

    void Start()
    {
        var getVolume = GetComponent<PostProcessVolume>();
        volume = getVolume;
        volume.profile.TryGetSettings(out bloom);
    }
 
    public void Update()
    {
        if (Mathf.Sin(Time.time) * amplify < 60) 
        {
            bloom.intensity.value = Random.Range(58.0f, 63.0f);
        }
        else
        {
            bloom.intensity.value = Mathf.Sin(Time.time) * amplify;
        }
    }
}
