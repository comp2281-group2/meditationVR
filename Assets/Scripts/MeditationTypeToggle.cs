using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MeditationTypeToggle : MonoBehaviour
{
    public bool myToggle;
    public AudioSource mainCameraComponent;
    public DisplayTimedSubtitles subtitleCanvas;
    public AudioClip audioClip0;
    public AudioClip audioClip1;
    public TextAsset scriptFile0;
    public TextAsset scriptFile1;
    
    void Start()
    {
        myToggle = GameObject.Find("ToggleHolder").GetComponent<ToggleFunc>().myToggle;
        Debug.Log(myToggle);
        if (myToggle) {
            Debug.Log("index: 0  . 5 min meditation");
            subtitleCanvas.subtitleFile = scriptFile0;
            mainCameraComponent.clip = audioClip0;
        } else if (!myToggle) {
            Debug.Log("Index: 1  . Meditation Breath Sound Body");
            subtitleCanvas.subtitleFile = scriptFile1;
            mainCameraComponent.clip = audioClip1;
        } else {
            Debug.Log("default option, 5 min meditation");
            subtitleCanvas.subtitleFile = scriptFile0;
            mainCameraComponent.clip = audioClip0;
        };
        mainCameraComponent.Play();
    }
}
