using UnityEngine;
using UnityEngine.Audio;

public class SetVolume : MonoBehaviour
{
    [SerializeField]
    private AudioMixer _mixer;

    public void SetLevel(float sliderValue)
    {
        _mixer.SetFloat("SoundVolume", Mathf.Log10(sliderValue) * 20);
    }
}
