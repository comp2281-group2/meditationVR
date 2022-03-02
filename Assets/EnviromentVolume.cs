using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class EnviromentVolume : MonoBehaviour {
    public AudioMixer audioMixer;
    public void VolSetter(float vol) {
        audioMixer.SetFloat("EnviromentVolume", Mathf.Log10(vol) * 25);
    }
}

