using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using System;
using System.IO;
using TMPro;

public class DisplayTimedSubtitles : MonoBehaviour
{
    
    public TextAsset subtitleFile;     // format of each line:  <subtitle text>#<duration of the line, time when next line begins-time when this line starts>     # is the delimeter; Drag the text file in the inspector
    public TMP_Text textComponent;
    private bool isEnd = false;
    private bool isActive = false;
    private List<SubtitleLine> lines = new List<SubtitleLine>();

    class SubtitleLine
    {
        public string subtitle { get; set; }
        public int timeDelay { get; set; }
    }
   
    void Start()
    {
        string text = subtitleFile.text;  //this is the content as string
        using (StringReader reader = new StringReader(text))
        {
            string line = string.Empty;
            do
            {
                line = reader.ReadLine();
                if (line != null)
                {
                    string[] splitLine = line.Split("#");
                    if (splitLine.Length == 2) 
                    {
                        int duration = int.Parse(splitLine[1]);
                        string subtitle = splitLine[0];
                        SubtitleLine subtitleLineObject = new SubtitleLine { subtitle = subtitle, timeDelay = duration };
                        lines.Add(subtitleLineObject);
                        
                    }
                }

            } while (line != null);
        }
    }

    private int lineNumber = 0;
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
    }

    private void ChangeTextTo(string text)
    {
        textComponent.text = text;
    }
}
