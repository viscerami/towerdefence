using UnityEngine;
using UnityEngine.UI;

namespace  Scene
{
    public class AudioManager : MonoBehaviour
    {
        [SerializeField] private AudioSource backgroundMusic; 
        [SerializeField] private Slider volumeSlider; 

        void Start()
        {
            volumeSlider.value = PlayerPrefs.GetFloat("Volume", .1f); 
            backgroundMusic.volume = volumeSlider.value;
            
            volumeSlider.onValueChanged.AddListener(SetVolume);
        }

        private void SetVolume(float volume)
        {
            backgroundMusic.volume = volume;
            PlayerPrefs.SetFloat("Volume", volume);
        }
    }
}
