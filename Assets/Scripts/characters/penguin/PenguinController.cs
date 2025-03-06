using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PenguinController : MonoBehaviour, IInteractable
{
    private PenguinAnimationController _penguinAnimationController;

    private void Awake()
    {
        _penguinAnimationController = new PenguinAnimationController(GetComponent<Animator>());
    }

    public void Interact()
    {
        _penguinAnimationController.SetTrigger(PenguinAnimationType.JumpTrigger);
    }
}
