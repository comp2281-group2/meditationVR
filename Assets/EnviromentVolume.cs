using UnityEngine;
using UnityEngine.Audio;

public class EnviromentVolume : MonoBehaviour {
    private const string GROUP_NAME = "Environment";

    public AudioMixer audioMixer;
    private AudioVolumes vols;

    public void Awake() {
        // load the saved volume from SavedPreferences
        vols = AudioVolumes.FromPreferences();
        audioMixer.SetFloat(GROUP_NAME, Mathf.Log10(vols.Environment) * 20);
    }

    public void VolSetter(float vol) {
        audioMixer.SetFloat(GROUP_NAME, Mathf.Log10(vol) * 20);
    }
}
