using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartController : MonoBehaviour
{
    private Animator _animator;

    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    public void TriggerHeartShaker()
    {
        _animator.SetTrigger("HeartReduce");
    }
}
