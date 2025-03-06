using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(AudioSource))]
public class SFXPlayer : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    private AudioSource _audioSource;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        _audioSource.Play();
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        _audioSource.Stop();
    }
}
