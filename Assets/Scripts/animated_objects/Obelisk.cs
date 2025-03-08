using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obelisk : MonoBehaviour, IInteractable
{
    private Animator _animator;

    private bool _isAnimated = false;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void Interact()
    {
        if (!_isAnimated)
        {
            _isAnimated = true;

            int randomIndex = Random.Range(0, 3);
            _animator.SetInteger("DisturbInt", randomIndex);

            StartCoroutine(WaitEndAnimation());
        }
    }

    IEnumerator WaitEndAnimation()
    {
        yield return null;

        AnimatorStateInfo stateInfo = _animator.GetCurrentAnimatorStateInfo(0);

        while (stateInfo.IsName("DisturbInt") && stateInfo.normalizedTime < 1.0f)
        {
            stateInfo = _animator.GetCurrentAnimatorStateInfo(0);
            yield return null;
        }

        _animator.SetInteger("DisturbInt", 3);
        _isAnimated = false;
    }
}
