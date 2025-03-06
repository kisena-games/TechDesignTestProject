using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PenguinController : MonoBehaviour, IInteractable
{
    [SerializeField] private PenguinType type = PenguinType.None;

    private PenguinAnimationController _penguinAnimationController;

    private void Awake()
    {
        _penguinAnimationController = new PenguinAnimationController(GetComponent<Animator>(), type);
    }

    public void Interact()
    {
        _penguinAnimationController.Animate();
    }
}

public enum PenguinType
{
    None,
    Jump,
    Attack
}
