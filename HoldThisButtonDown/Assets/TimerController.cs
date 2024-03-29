using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerController : MonoBehaviour
{
    public static TimerController instance;
    public Text timeCounter;
    public int timePlayingInt;
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
        timeCounter.text = "0.00:00:00.00";
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
            timePlayingInt = (int) Math.Round(timePlaying.TotalSeconds,MidpointRounding.AwayFromZero);
            string timePlayingStr = timePlaying.ToString("d'.'hh':'mm':'ss'.'ff");
            timeCounter.text = timePlayingStr;

            yield return null;
        }
    }
    public int getTimePlaying()
    {
            return timePlayingInt;
        
    }

}
