using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
Zachary Durick
5/21/2023
Flappy Bird final project
AP Computer Science

Description of TimerController class:
=====================================
Class handles our game timer
Always resets to 00:00:00
updateTimer() continusouly updates
*/

public class TimerController : MonoBehaviour
{
    public static TimerController instance;  //allows us to call from other C# scripts
    public Text timeCounter;
    private TimeSpan timePlaying;
    private bool timerGoing;
    private float elapsedTime;

    private void Awake() {
        instance = this;
    }

    public void ChangeTextColor(){
        timeCounter.color = Color.red;

    }
    // Start is called before the first frame update
    void Start()
    {
        timeCounter.text = "Timer:  00:00:00";
        timerGoing = false;
        
    }
    //starts the timer with all zeros
    public void BeginTimer(){
        timerGoing = true;
        elapsedTime = 0f;

        StartCoroutine(UpdateTimer());
    }

    // ends the timer
    public void EndTimer(){
        timerGoing = false;
    }

    // updates the timer
    private IEnumerator UpdateTimer(){
        while(timerGoing){
            elapsedTime += Time.deltaTime;
            timePlaying = TimeSpan.FromSeconds(elapsedTime);
            string timePlayingStr = "Timer: " + timePlaying.ToString("mm':'ss'.'ff");
            timeCounter.text = timePlayingStr;

            yield return null;  //returns on next frame!
        }

    }


}
