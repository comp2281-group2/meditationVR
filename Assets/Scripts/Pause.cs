using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class Pause : MonoBehaviour
{
    public GameObject pauseMenu;
    public bool isPaused;
    public bool isPauseMenuDisplayed;
    public AudioSource mainCameraComponent;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        
        
    }

    public void ResumeGame() {
        isPaused = false;
        Time.timeScale = 1;
        //resume adio
        mainCameraComponent.Play();

    }
    public void PauseGame() {
        Time.timeScale = 0;
        isPaused = true;
        //pause audio
        mainCameraComponent.Pause();


    }
    public void OnMenu(InputValue buttonValue) {
        if (buttonValue.isPressed) {
            isPaused = !isPaused;
        }
    }
    private void OnAny(InputValue value) {
        Debug.Log("Esc pressed");
    }
    public void OnPause(InputValue value)
    {
        Debug.Log("Esc pressed");
    }
    public void Test() {
        Debug.Log("Test");
    }
    
}
