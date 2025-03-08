using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cloud2 : MonoBehaviour
{
    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void Start()
    {
        StartCoroutine(WaitToAnimation());
    }

    private IEnumerator WaitToAnimation()
    {
        yield return new WaitForSeconds(2f);

        _animator.enabled = true;
    }
}
