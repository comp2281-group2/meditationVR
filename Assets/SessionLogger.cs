using System;
using System.IO;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// A log event to be written to JSON
/// </summary>
[Serializable]
public struct SessionLog {
    /// <summary>Time the session started</summary>
    public string Start;

    /// <summary>Time the session ended</summary>
    public string End;

    /// <summary>Duration of the session in seconds</summary>
    public long Duration;

    /// <summary>Name of the scene that was played</summary>
    public string SceneTitle;

    public string ToJson()
    {
        return JsonUtility.ToJson(this);
    }
}

/// <summary>
/// A logger for session-level data. Each <c>SessionLogger</c> records:
/// <list type="bullet">
///     <item>when a user opens a session</item>
///     <item>when a user closes a session</item>
///     <item>the session the user was playing</item>
/// </list>
/// and writes this information to an event log (unstructured data for
/// debugging) and a session log (JSON data for use in-game). 
///
/// Once we've added proper gameplay there will be interesting data to log.
/// For now we just store data and time.
/// </summary>
public class SessionLogger : MonoBehaviour
{
    /// <summary>Name of the session log file</summary>
    const string FILENAME = "session_log.json";

    /// <summary> </summary>
    string sceneName = "uninitialised";

    DateTime start;     

    // `Awake` is called when the attached scene is created
    void Awake()
    {
        sceneName = SceneManager.GetActiveScene().name;
    }

    // `Start` is called just before the first frame of the attached scene is rendered
    void Start()
    {
        start = DateTime.Now;

        log("session logger starting");
    }

    // `OnDestroy` is called when the attached scene ends
    void OnDestroy()
    {
        log("called OnDestroy");
        
        var end = DateTime.Now;
        long duration = (end - start).Seconds;

        logSession(new SessionLog { 
            Start = start.ToString(), 
            End = end.ToString(),
            Duration = duration,
            SceneTitle = sceneName,    
        });
    }

    /// A better way of managing this may be to have a singleton that tracks all
    /// 
    ///
    /// <summary>
    /// <para>Writes a new session to the session log.</para>
    ///
    /// <c>session_log.json</c> has the format:
    ///     <code>
    ///         {
    ///             "Items": [
    ///                 {"start: ...,"end:" ...},
    ///                 {"start: ...,"end:" ...}
    ///             ]
    ///         }
    ///     </code>
    /// JsonHelper will automatically deserialise it to a <c>SessionLog</c> array.
    /// </summary>
    private void logSession(SessionLog newSession)
    {
        string path = Application.persistentDataPath + "/" + FILENAME;
        SessionLog[] sessions;

        if (File.Exists(path)) {
            log("Found existing session log file");
            
            // Create a new SessionLog array, and copy `old` to it
            var old = LoadSessions(path);
            sessions = new SessionLog[old.Length + 1];

            for (int i = 0; i < old.Length; i++)
                sessions[i] = old[i];

            sessions[sessions.Length - 1] = newSession;

        } else {
            log("Found no session log file");
            sessions = new [] { newSession };
        }

        log("Writing new session to " + path);
        System.IO.File.WriteAllText(path, JsonHelper.ToJson(sessions));
    }

    /// <summary>
    /// Load the session log stored at <c>path</c>.
    /// Assumes that the file exists.
    /// </summary>
    ///
    /// <param name="path">Location of the file to read the session logs from</param>
    ///
    public static SessionLog[] LoadSessions(string path)
    {
        return JsonHelper.FromJson<SessionLog>(
            System.IO.File.ReadAllText(path)
        );
    } 

    /// <summary>Log a message the the console</summary>
    /// EZ to repurpose for different log levels/output targets
    private void log(string message)
    {
        Debug.Log(String.Format("SessionLogger ({0}): {1}", sceneName, message));
    }
}

// Code taken from https://stackoverflow.com/questions/36239705/serialize-and-deserialize-json-and-json-array-in-unity
// JsonUtility doesn't handle arrays of objects (as we need here)
public static class JsonHelper
{
    public static T[] FromJson<T>(string json)
    {
        Wrapper<T> wrapper = JsonUtility.FromJson<Wrapper<T>>(json);
        return wrapper.Items;
    }

    public static string ToJson<T>(T[] array)
    {
        Wrapper<T> wrapper = new Wrapper<T>();
        wrapper.Items = array;
        return JsonUtility.ToJson(wrapper);
    }

    public static string ToJson<T>(T[] array, bool prettyPrint)
    {
        Wrapper<T> wrapper = new Wrapper<T>();
        wrapper.Items = array;
        return JsonUtility.ToJson(wrapper, prettyPrint);
    }

    [Serializable]
    private class Wrapper<T>
    {
        public T[] Items;
    }
}
