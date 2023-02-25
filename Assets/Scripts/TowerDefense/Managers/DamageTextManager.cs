using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageTextManager : Singleton<DamageTextManager>
{
    public ObjectPooler Pooler { get; set; }
    
    // Start is called before the first frame update
    private void Start()
    {
        Pooler = GetComponent<ObjectPooler>();
    }
}
