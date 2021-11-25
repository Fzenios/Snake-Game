using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class OptionsManager : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioMixer audioMixer;
    static float volumelock;
    public float volume; 
    public Slider slider;

    private void Awake() {
           
        slider.value = volumelock;
    }

    private void Update() {
        //slider.value = Mathf.MoveTowards (slider.value, 100.0f, 0.15f);
    }
    public void SetVolume (float volume)
    { 
        //Debug.Log(volumelock);
        audioMixer.SetFloat("volume", volume);
        volumelock = volume;
    }

    
}
