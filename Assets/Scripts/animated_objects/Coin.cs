using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Coin : MonoBehaviour, IInteractable
{
    [SerializeField] private ParticleSystem _particleSystem;

    private AudioSource _audioSource;
    private bool _isCollected = false;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    public void Interact()
    {
        if (!_isCollected)
        {
            _isCollected = true;
            StartCoroutine(WaitToCollect());
        }
    }

    private IEnumerator WaitToCollect()
    {
        _particleSystem.Play();
        _audioSource.Play();

        while (_audioSource.isPlaying && _particleSystem.isPlaying)
        {
            yield return null;
        }

        Destroy(gameObject);
    }
}
