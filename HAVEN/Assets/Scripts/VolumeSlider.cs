using UnityEngine;
using UnityEngine.Audio;

public class VolumeSlider : MonoBehaviour
{
    public AudioMixer mixer;

    public void setVolume(float sliderValue)
    {
        mixer.SetFloat("Volume", Mathf.Log10(sliderValue)*20);
    }
}
