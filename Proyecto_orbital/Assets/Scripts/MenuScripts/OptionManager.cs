using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionManager : MonoBehaviour
{
    [SerializeField] private Slider volumenSlider;
    [SerializeField] private Toggle volumenToggle;
    [SerializeField] private Slider volumenMusicSlider;
    [SerializeField] private Toggle volumenMusicToggle;
    [SerializeField] private AudioSource musicAudioSource;
    [SerializeField] private Slider volumenSFXSlider;
    [SerializeField] private Toggle volumenSFXToggle;
    [SerializeField] private AudioSource sFXAudioSource;

    private void Start()
    {
        volumenSlider.value = GameManager.instance.Options.generalVolumen;
        volumenMusicSlider.value = GameManager.instance.Options.musicVolumen;
        volumenSFXSlider.value = GameManager.instance.Options.sFXVolumen;
    }

    public void ChangeValueVolumen(int volume)
    {
        switch (volume)
        {
            case 1:
                volumenMusicSlider.value = volumenSlider.value;
                volumenSFXSlider.value = volumenSlider.value;
                if(volumenSlider.value == 0) { volumenToggle.isOn = true; }
                else { volumenToggle.isOn = false; }
                break;
            case 2:
                if(volumenMusicSlider.value == 0) { volumenMusicToggle.isOn = true; }
                else { volumenMusicToggle.isOn = false; }
                //musicAudioSource.volume = volumenMusicSlider.value;
                break;
            case 3:
                if (volumenSFXSlider.value == 0) { volumenSFXToggle.isOn = true; }
                else { volumenSFXToggle.isOn = false; }
                //sFXAudioSource.volume = volumenSFXSlider.value;
                break;
        }
        SaveOptions();
    }
    public void ChangeToggleValue(int volume)
    {
        switch (volume)
        {
            case 1:
                if(volumenToggle.isOn == true)
                {
                    volumenMusicToggle.isOn = true;
                    volumenSFXToggle.isOn = true;
                }
                break;
            case 2:
                if(volumenMusicToggle.isOn == true) { volumenMusicSlider.value = 0; }
                break;
            case 3:
                if (volumenSFXToggle.isOn == true) { volumenSFXSlider.value = 0; }
                break;
        }
    }
    public void SaveOptions()
    {
        GameManager.instance.Options.generalVolumen = (int)volumenSlider.value;
        GameManager.instance.Options.musicVolumen = (int)volumenMusicSlider.value;
        GameManager.instance.Options.sFXVolumen = (int)volumenSFXSlider.value;
        GameManager.instance.Save();
    }
}
