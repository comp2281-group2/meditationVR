using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class Pause : MonoBehaviour
{
    public GameObject PauseMenu;
    public bool isPaused;
    public bool isPauseMenuDisplayed;
    public AudioSource mainCameraComponent;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isPaused)
        {
            if (!isPauseMenuDisplayed) {
                PauseGame();
            }
        }
        else
        {
            if (isPauseMenuDisplayed)
            {
                ResumeGame();
            }
        }
        
        
    }

    public void ResumeGame() {
        isPaused = false;
        isPauseMenuDisplayed = false;
        PauseMenu.SetActive(false);
        Time.timeScale = 1;
        //resume adio
        mainCameraComponent.Play();

    }
    public void PauseGame() {
        PauseMenu.SetActive(true);
        Time.timeScale = 0;
        //pause audio
        mainCameraComponent.Pause();
    }
    private void OnMenu(InputValue buttonValue) {
        if (buttonValue.isPressed) {
            isPaused = !isPaused;
        }
    }
    private void OnAny(InputValue value) {
        Debug.Log("Esc pressed");
    }
    void OnPause(InputValue value)
    {
        Debug.Log("Esc pressed");
    }
    
}
