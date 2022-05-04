using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerController : MonoBehaviour
{
    public static TimerController instance;
    public Text timeCounter;

    private TimeSpan timePlaying;
    private bool timerGoing;

    private float elapsedTime;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        timeCounter.text = "0";
        timerGoing = false;
    }

    public void BeginTimer()
    {
        timerGoing = true;
        elapsedTime = 0f;

        StartCoroutine(UpdateTimer());
    }
    public void EndTimer()
    {
        timerGoing = false;
    }
    private IEnumerator UpdateTimer()
    {
        while (timerGoing)
        {
            elapsedTime += Time.deltaTime;
            timePlaying = TimeSpan.FromSeconds(elapsedTime);
            string timePlayingStr = GetSimplestTimeSpan(timePlaying);
            timeCounter.text = timePlayingStr;

            yield return null;
        }
    }

    public static string GetSimplestTimeSpan(TimeSpan timeSpan)
    {
        var result = string.Empty;
        if (timeSpan.Days > 0)
        {
            result += string.Format(@"{0:ddd\.}", timeSpan).TrimStart('0');
        }
        if (timeSpan.Hours > 0)
        {
            result += string.Format( @"{0:hh\:}", timeSpan).TrimStart('0');
        }
        if (timeSpan.Minutes > 0)
        {
            result += string.Format(@"{0:mm\:}", timeSpan).TrimStart('0');
        }
        if (timeSpan.Seconds > 0)
        {
            result += string.Format(@"{0:ss\:}", timeSpan).TrimStart('0');
        }
        if (timeSpan.Milliseconds > 0)
        {
            result += string.Format( @"{0:ff}", timeSpan).TrimStart('0');
            
        }
        return result;
    }

}
