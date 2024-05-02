using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(AudioSource))]

public class VolumeController : MonoBehaviour, IServiceLocator
{
    public Slider volumeSlider;
    private AudioSource audioSource;

    public void Init()
    {
        audioSource = GetComponent<AudioSource>();
        volumeSlider.value = audioSource.volume;
    }

    public void ChangeVolume()
    {
        audioSource.volume = volumeSlider.value;
    }

}