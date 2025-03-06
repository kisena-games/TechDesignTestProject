using System;
using System.Collections.Generic;
using UnityEngine;

public class PenguinAnimationController
{
    private readonly Animator _animator;
    private readonly PenguinType _type;

    private readonly Dictionary<PenguinAnimationType, int> tankAnimationTypeHash = new Dictionary<PenguinAnimationType, int>();

    public Animator Animator => _animator;

    public PenguinAnimationController(Animator animator, PenguinType type)
    {
        _animator = animator;
        _type = type;

        foreach (PenguinAnimationType tankAnimationType in Enum.GetValues(typeof(PenguinAnimationType)))
        {
            tankAnimationTypeHash.Add(tankAnimationType, Animator.StringToHash(tankAnimationType.ToString()));
        }
    }

    public void Animate()
    {
        switch (_type)
        {
            case PenguinType.Jump:
                _animator.SetTrigger(tankAnimationTypeHash[PenguinAnimationType.JumpTrigger]);
                break;
            case PenguinType.Attack:
                _animator.SetTrigger(tankAnimationTypeHash[PenguinAnimationType.AttackTrigger]);
                break;
            default:
                break;
        }
    }

    private void SetBool(PenguinAnimationType tankAnimationType, bool value)
    {
        _animator.SetBool(tankAnimationTypeHash[tankAnimationType], value);
    }
}

public enum PenguinAnimationType
{
    JumpTrigger,
    AttackTrigger
}
