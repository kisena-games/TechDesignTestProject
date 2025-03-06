using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.ParticleSystem;

[RequireComponent(typeof(AudioSource))]
public class PenguinController : MonoBehaviour, IInteractable
{
    [SerializeField] private PenguinType type = PenguinType.None;
    [SerializeField] private ParticleSystem _particles;

    private AudioSource _audioSource;
    private PenguinAnimationController _penguinAnimationController;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
        _penguinAnimationController = new PenguinAnimationController(GetComponent<Animator>(), type);
    }

    public void Interact()
    {
        _penguinAnimationController.Animate();
        _particles.Play();
        _audioSource.Play();
    }
}

public enum PenguinType
{
    None,
    Jump,
    Attack
}
