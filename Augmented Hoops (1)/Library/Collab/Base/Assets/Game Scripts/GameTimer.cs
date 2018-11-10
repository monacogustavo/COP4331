using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour {

    public Text timerText;
    private float startTime;
    // TODO: base this off of game settings using PlayerPrefs
    private float gameDuration = 30f;

	// initialize start time
	void Start () {
        startTime = Time.time;
	}
	
	// update timer text every frame
	void Update () {
        float elapsedTime = Time.time - startTime;

        float timeRemaining = gameDuration - elapsedTime;

        string minutesRemaining = ((int)timeRemaining / 60).ToString();
        string secondsRemaining = (timeRemaining % 60).ToString("f2");

        // format newly calculated timer string to be displayed
        string newText = minutesRemaining + ":" + secondsRemaining;

        if (gameDuration < 60f)
        {
            newText = secondsRemaining;
        }

        timerText.text = newText;
	}
}
