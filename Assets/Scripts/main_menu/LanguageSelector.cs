using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Localization;
using UnityEngine.Localization.Settings;
using System.Collections.Generic;
using TMPro;
using UnityEngine.Localization.Components;

public class LanguageSelector : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI languageText;

    private const string SELECTED_LANGUAGE_KEY = "SelectedLanguage";
    private const string LOCALIZATION_TABLE_NAME = "LocalizationTextTable";

    private List<TextMeshProUGUI> _uiTextElements = new List<TextMeshProUGUI>();
    private Dictionary<string, string> _languages = new Dictionary<string, string>();

    private int _currentLanguageIndex = 0;
    private List<string> _locales;

    private void Awake()
    {
        _languages.Add("English (en)", "English");
        _languages.Add("Russian (ru)", "Русский");

        var tempTextElements = FindObjectsByType<LocalizeStringEvent>(FindObjectsSortMode.None);

        foreach (var textElement in tempTextElements)
        {
            var textMeshPro = textElement.gameObject.GetComponent<TextMeshProUGUI>();
            _uiTextElements.Add(textMeshPro);
        }

        _locales = new List<string>(_languages.Keys);
    }

    private void Start()
    {
        LoadLanguage();
        UpdateLanguage();
    }

    public void SelectPreviousLanguage()
    {
        _currentLanguageIndex--;
        if (_currentLanguageIndex < 0)
        {
            _currentLanguageIndex = 0;
            return;
        }
        UpdateLanguage();
        SaveLanguage();
    }

    public void SelectNextLanguage()
    {
        _currentLanguageIndex++;
        if (_currentLanguageIndex >= _locales.Count)
        {
            _currentLanguageIndex = _locales.Count - 1;
            return;
        }
        UpdateLanguage();
        SaveLanguage();
    }

    private void UpdateLanguage()
    {
        string localeKey = _locales[_currentLanguageIndex];
        languageText.text = _languages[localeKey];
        ChangeLocalization(localeKey);
    }

    private void ChangeLocalization(string localeKey)
    {
        var locale = LocalizationSettings.AvailableLocales.Locales.Find(l => l.name == localeKey);
        LocalizationSettings.SelectedLocale = locale;

        foreach (var uiText in _uiTextElements)
        {
            uiText.text = LocalizationSettings.StringDatabase.GetLocalizedString(LOCALIZATION_TABLE_NAME, uiText.name);
        }
    }

    private void SaveLanguage()
    {
        PlayerPrefs.SetString(SELECTED_LANGUAGE_KEY, _locales[_currentLanguageIndex]);
        PlayerPrefs.Save();
    }

    private void LoadLanguage()
    {
        if (PlayerPrefs.HasKey(SELECTED_LANGUAGE_KEY))
        {
            string savedLocaleKey = PlayerPrefs.GetString(SELECTED_LANGUAGE_KEY);
            _currentLanguageIndex = _locales.IndexOf(savedLocaleKey);
            if (_currentLanguageIndex < 0)
            {
                _currentLanguageIndex = 0;
            }
        }
        else
        {
            _currentLanguageIndex = 0;
        }
    }
}
