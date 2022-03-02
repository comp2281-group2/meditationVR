using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class MasterVolume : MonoBehaviour{
    public AudioMixer audioMixer;
    public void VolSetter(float vol) {
        audioMixer.SetFloat("MasterVolume", Mathf.Log10(vol) * 25);
    }
}
