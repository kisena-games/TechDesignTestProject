using System;
using System.Collections.Generic;
using UnityEngine;

public class PenguinAnimationController
{
    private readonly Animator _animator;

    private readonly Dictionary<PenguinAnimationType, int> tankAnimationTypeHash = new Dictionary<PenguinAnimationType, int>();

    public Animator Animator => _animator;

    public PenguinAnimationController(Animator animator)
    {
        _animator = animator;
        foreach (PenguinAnimationType tankAnimationType in Enum.GetValues(typeof(PenguinAnimationType)))
        {
            tankAnimationTypeHash.Add(tankAnimationType, Animator.StringToHash(tankAnimationType.ToString()));
        }
    }

    public void SetBool(PenguinAnimationType tankAnimationType, bool value)
    {
        _animator.SetBool(tankAnimationTypeHash[tankAnimationType], value);
    }

    public void SetTrigger(PenguinAnimationType tankAnimationType)
    {
        _animator.SetTrigger(tankAnimationTypeHash[tankAnimationType]);
    }

    public void PlayAnimator()
    {
        _animator.enabled = true;
    }

    public void StopAnimator()
    {
        _animator.enabled = false;
    }
}

public enum PenguinAnimationType
{
    JumpTrigger
}
