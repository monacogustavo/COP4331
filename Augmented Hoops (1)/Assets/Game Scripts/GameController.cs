using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class GameController : MonoBehaviour {

    public GameTimer gameTimer;
    public SpawnBall ballSpawner;
    public SettingsController settingsController;
    public BackAndForth backAndForth;

    public TextMeshProUGUI ScoreText;
    public TextMeshProUGUI FinalScoreText;
    public GameObject GameUIPanel;
    public GameObject PostGamePanel;
    public GameObject NewHighScorePanel;

    private int shotsMade = 0;
    private int shotsTaken = 0;
    private int points = 0;
    private bool postGame = false;

    private int toggleHoopMovementAt = 0;
    private int toggleHoopInterval = 3;
    private float finalCountdown = 0.0f;

	void Start () {
        GameUIPanel.SetActive(true);
        PostGamePanel.SetActive(false);
        NewHighScorePanel.SetActive(false);
	}

    public void loadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    // manage game state every frame
    void Update () {
        if (gameTimer.gameStarted && !gameTimer.gameOver)
        {
            if (toggleHoopMovementAt == (int)(gameTimer.timeRemaining) && toggleHoopMovementAt > 0)
            {
                backAndForth.TogglePause();
                toggleHoopMovementAt -= toggleHoopInterval;
            }

            ballSpawner.trySpawn();
        }
        if (gameTimer.gameOver && GameObject.Find("basketball(Shot)") == null && postGame == false)
        {
            backAndForth.Pause();

            GameUIPanel.SetActive(false);

            FinalScoreText.text = points.ToString();

            if (settingsController.NewHighScoreCheck(shotsMade))
            {
                NewHighScorePanel.SetActive(true);
            }
            else
            {
                PostGamePanel.SetActive(true);
                postGame = true;
            }
        }
	}

    public void StartGame() {
        if (!gameTimer.gameStarted)
        {
            if (settingsController.gameDifficulty == GameDifficulty.hard)
            {
                backAndForth.Unpause();
            }
            else if (settingsController.gameDifficulty == GameDifficulty.medium)
            {
                backAndForth.Unpause();
                toggleHoopMovementAt = settingsController.gameDuration - toggleHoopInterval;
            }
            else
            {
                backAndForth.Pause();
            }

            gameTimer.countdownAndStart(settingsController.gameDuration);
        }
    }

    public void shotTaken()
    {
        shotsTaken++;

        // update ball-last-shot-at timer
        ballSpawner.updateBallShotTimer();
    }

    public void shotMade()
    {
        shotsMade++;

        points += (int)settingsController.gameDifficulty;

        ScoreText.text = points.ToString();
    }

    public void submitNewScore(TMP_InputField initialsInput)
    {
        string initials = initialsInput.text;
        if (initials == "enter initials")
            initials = "";

        settingsController.AddNewHighScore(initials, points);

        NewHighScorePanel.SetActive(false);
        PostGamePanel.SetActive(true);
        postGame = true;
    }
}
