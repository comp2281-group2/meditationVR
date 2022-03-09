using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleFunc : MonoBehaviour
{
    public bool myToggle;
    void Start()
    {
        DontDestroyOnLoad(this);
        myToggle = true;
    }

    public void invertToggle()
    {
        myToggle = !myToggle;
    }
}
