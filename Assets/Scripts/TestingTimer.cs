using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using System;
using TMPro;

public class TestingTimer : MonoBehaviour
{
    private bool isActive = false;
    public TMP_Text textComponent;
    private bool isEnd = false;

    private class SubtitleLine
    {
        public string subtitle { get; set; }
        public int timeDelay { get; set; }
    }

    private List<SubtitleLine> lines = new List<SubtitleLine> {
        new SubtitleLine { subtitle="Find a relaxed, comfortable position", timeDelay= 3},
        new SubtitleLine { subtitle="Seated on a chair or on the floor, on a cushion",timeDelay=10},
        new SubtitleLine { subtitle="Keep your back upright, but not too tight",timeDelay=6},
        new SubtitleLine { subtitle="Hands resting wherever they're comfortable",timeDelay=6},
        new SubtitleLine { subtitle="Tongue on the roof of your mouth or wherever it's comfortable.",timeDelay=7},
        new SubtitleLine { subtitle="And you can notice your body",timeDelay=3},
        new SubtitleLine { subtitle="From the inside",timeDelay=3},
        new SubtitleLine { subtitle="Noticing the shape of your body, the weight, touch",timeDelay=11},
        new SubtitleLine { subtitle="And let yourself relax",timeDelay=3},
        new SubtitleLine { subtitle="And become curious about your body",timeDelay=5},
        new SubtitleLine { subtitle="Seated here",timeDelay=2},
        new SubtitleLine { subtitle="The sensations of your body, the touch",timeDelay=6},
        new SubtitleLine { subtitle="The connection with the floor, the chair",timeDelay=5},
        new SubtitleLine { subtitle="Relax any areas of tightness or tension",timeDelay=8},
        new SubtitleLine { subtitle="Just breathe, soften",timeDelay=7},
        new SubtitleLine { subtitle="And now begin to tune into your breath",timeDelay=6}
    };
    private int lineNumber = 0;
    /*public void Start()
    {
        StartCoroutine(Timer(0));

    }*/

    public void Update() 
    {
        if (isActive == false && isEnd == false) 
        {
            string text = lines[lineNumber].subtitle;
            int duration = lines[lineNumber].timeDelay;
            ChangeTextTo(text);
            StartCoroutine(Timer(duration));
            lineNumber += 1;
            if (lines.Count < lineNumber + 1) 
            {
                isEnd = true;
            }
        }
    }

    IEnumerator Timer(int duration)
    {
        isActive = true;
        yield return new WaitForSeconds(duration);
        isActive = false;
        Debug.Log("Timer has ended");
    }

    private void ChangeTextTo(string text)
    {
        textComponent.text = text;
    }
}
