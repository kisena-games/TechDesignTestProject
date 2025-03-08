using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class VolumeSettings : MonoBehaviour
{
    [SerializeField] private AudioMixer audioMixer;
    [SerializeField] private Slider musicSlider;
    [SerializeField] private Slider sfxSlider;

    private const string MUSIC_VOLUME_KEY = "MusicVolume";
    private const string SFX_VOLUME_KEY = "SFXVolume";

    private float _defaultVolume = 0.5f;

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
        LoadVolume(_defaultVolume);
    }

    private void LoadVolume(float volume)
    {
        sfxSlider.value = PlayerPrefs.GetFloat(SFX_VOLUME_KEY, volume);
        musicSlider.value = PlayerPrefs.GetFloat(MUSIC_VOLUME_KEY, volume);
    }

    public void SetMusicVolume(float volume)
    {
        audioMixer.SetFloat(MUSIC_VOLUME_KEY, Mathf.Log10(volume) * 20);
        PlayerPrefs.SetFloat(MUSIC_VOLUME_KEY, volume);
    }

    public void SetSFXVolume(float volume)
    {
        audioMixer.SetFloat(SFX_VOLUME_KEY, Mathf.Log10(volume) * 20);
        PlayerPrefs.SetFloat(SFX_VOLUME_KEY, volume);
    }
}
