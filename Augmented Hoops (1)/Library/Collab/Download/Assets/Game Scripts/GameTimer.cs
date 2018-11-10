using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameTimer : MonoBehaviour {

    public TextMeshProUGUI CountdownText;
    public TextMeshProUGUI TimerText;

    private float startTime;
    private float gameDuration = 30f;
    private float countDownStart;
    private float countDownTime = 3.0f;

    // flags to keep track of game state
    private bool countDownInitiated;

    private bool _gameStarted = false;
    public bool gameStarted {
        get { return _gameStarted; }
    }

    private bool _gameOver = false;
    public bool gameOver {
        get { return _gameOver; }
    }

    private float _timeRemaining = 0.0f;
    public float timeRemaining
    {
        get { return _timeRemaining; }
    }
	
	// update timers and game state every frame
	void Update () {

        if (countDownInitiated)
        {
            float elapsedTime = Time.time - countDownStart;

            // countdown is over, start game
            if (elapsedTime > countDownTime)
            {
                countDownInitiated = false;
                startTimer();
                return;
            }

            float countdownRemaining = countDownTime - elapsedTime;

            CountdownText.text = ((int)countdownRemaining + 1).ToString();
        }
        else if (_gameStarted && !_gameOver)
        {
            float elapsedTime = Time.time - startTime;
            
            _timeRemaining = gameDuration - elapsedTime;

            // game duration has expired, end game
            if (timeRemaining < 0.0f)
            {
                _timeRemaining = 0.0f;
                _gameOver = true;

                if (GameObject.Find("basketball(In-Hand)") != null)
                    Destroy(GameObject.Find("basketball(In-Hand)"));
            }

            TimerText.text = timeRemaining.ToString("0");
        }
	}

    // starts the game timer
    public void startTimer() {

        CountdownText.gameObject.SetActive(false);

        startTime = Time.time;
        _gameStarted = true;
    }

    // initiates countdown
    public void countdownAndStart(int duration) {

        gameDuration = duration;

        CountdownText.gameObject.SetActive(true);
        TimerText.gameObject.SetActive(true);

        countDownStart = Time.time;
        countDownInitiated = true;
    }

}
