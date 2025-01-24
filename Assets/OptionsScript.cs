using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class OptionsScript : MonoBehaviour
{
    [SerializeField]
    private AudioMixer audioMixer;
    [SerializeField]
    private Slider musicSlider;
    [SerializeField]
    private Slider effectsSlider;
    void Start()
    {
        float currentVolume = 0;
        if (audioMixer.GetFloat("Music", out currentVolume))
        {
            musicSlider.value = currentVolume;
        }
        if (audioMixer.GetFloat("Effects", out currentVolume))
        {
            effectsSlider.value = currentVolume;
        }
        musicSlider.onValueChanged.AddListener(SetMusicVolume);
        effectsSlider.onValueChanged.AddListener(SetEffectsVolume);
    }
    public void SetMusicVolume(float volume)
    {
        audioMixer.SetFloat("Music", volume);
    }
    public void SetEffectsVolume(float volume)
    {
        audioMixer.SetFloat("Effects", volume);
    }
}
