using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class VolumeSettings : MonoBehaviour
{
    [SerializeField] private AudioMixer audioMixer;
    [SerializeField] private Slider musicSlider;
    [SerializeField] private Slider sfxSlider;

    private const string MusicVolumeKey = "MusicVolume";
    private const string SFXVolumeKey = "SFXVolume";
    private const float defaultVolume = 0.5f;

    private void OnEnable()
    {
        sfxSlider.onValueChanged.AddListener(SetSFXVolume);
        musicSlider.onValueChanged.AddListener(SetMusicVolume);
    }

    private void OnDisable()
    {
        sfxSlider.onValueChanged.RemoveListener(SetSFXVolume);
        musicSlider.onValueChanged.RemoveListener(SetMusicVolume);
    }

    void Start()
    {
        LoadVolume(defaultVolume);
    }

    private void LoadVolume(float volume)
    {
        sfxSlider.value = PlayerPrefs.GetFloat(SFXVolumeKey, volume);
        musicSlider.value = PlayerPrefs.GetFloat(MusicVolumeKey, volume);
    }

    public void SetMusicVolume(float volume)
    {
        audioMixer.SetFloat(MusicVolumeKey, Mathf.Log10(volume) * 20);
        PlayerPrefs.SetFloat(MusicVolumeKey, volume);
    }

    public void SetSFXVolume(float volume)
    {
        audioMixer.SetFloat(SFXVolumeKey, Mathf.Log10(volume) * 20);
        PlayerPrefs.SetFloat(SFXVolumeKey, volume);
    }
}
