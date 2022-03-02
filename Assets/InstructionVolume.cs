using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class InstructionVolume : MonoBehaviour {
    public AudioMixer audioMixer;
    public void VolSetter(float vol) {
        audioMixer.SetFloat("InstructionVolume", Mathf.Log10(vol) * 25);
    }
}

