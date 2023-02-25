using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoDestroy : MonoBehaviour
{
    public int destroyDelay;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(this, 3);
    }

}
