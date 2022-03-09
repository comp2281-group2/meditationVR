using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeditationTypeDropdown : MonoBehaviour
{
    public int meditationType;
    void Start()
    {
        DontDestroyOnLoad(this);
        meditationType = 0;
    }

    public void changeMeditationType(int val)
    {
        meditationType = val;
    }
}
