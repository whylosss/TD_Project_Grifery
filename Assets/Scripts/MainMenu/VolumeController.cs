using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(AudioSource))]

public class VolumeController : MonoBehaviour
{
    public Slider volumeSlider;
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        volumeSlider.value = 100f;
    }

    private void Update()
    {
        ChangeVolume();
    }

    public void ChangeVolume()
    {
        audioSource.volume = volumeSlider.value;
    }

}