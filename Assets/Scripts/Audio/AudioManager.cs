using System;
using UnityEngine;

/// Stores the attenuation of each mixer channel
public struct AudioVolumes {
    private const float DEFAULT_MASTER = 0.0f;
    private const float DEFAULT_INSTRUCTIONS = -0.1f;
    private const float DEFAULT_ENVIRONMENT = -0.3f;

    public float Master;
    public float Instructions;
    public float Environment;

    public AudioVolumes(float master, float instructions, float environment) {
        this.Master = master;
        this.Instructions = instructions;
        this.Environment = environment;
    }
    
    /// Create an AudioVolumes object by reading from PlayerPreferences
    public static AudioVolumes FromPreferences() {
        float master = PlayerPrefs.GetFloat("vol_master", DEFAULT_MASTER);
        float narration = PlayerPrefs.GetFloat("vol_narration", DEFAULT_INSTRUCTIONS);
        float environment = PlayerPrefs.GetFloat("vol_environment", DEFAULT_ENVIRONMENT);

        return new AudioVolumes(master, narration, environment);
    }

    /// Save the current audio settings to PlayerPreferences
    public void SavePrefs() {
        PlayerPrefs.SetFloat("vol_master", Master);
        PlayerPrefs.SetFloat("vol_narration", Instructions);
        PlayerPrefs.SetFloat("vol_environment", Environment);
    }

    public override string ToString() {
        return String.Format("master: {0}, instructions: {1}, environment: {2}", Master, Instructions, Environment);
    }
}

public class AudioManager : MonoBehaviour
{
    private AudioVolumes settings;

    void Awake() {  
        this.settings = AudioVolumes.FromPreferences();
        Debug.Log(String.Format("loaded audio settings {0}", settings.ToString()));

        // get MasterMixer
        // get groups
        // set attenuation of each group
        
        Debug.Log("Set volumes from PlayerPreferences");
    }
}
