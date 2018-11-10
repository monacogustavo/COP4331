using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

// this file will control all actions from the main menu (initiating game, viewing high scores panel, etc)
public class MainMenuController : MonoBehaviour {

    public SettingsController settingsController;

    public TextMeshProUGUI GameDurationLabel;
    public TextMeshProUGUI GameDifficultyLabel;
    public TextMeshProUGUI ShotSensitivityLabel;

    public Slider GameDurationSlider;
    public Slider GameDifficultySlider;
    public Slider ShotSensitivitySlider;

    private void Start()
    {
        TextMeshProUGUI[] textMeshProUGUIs = FindObjectsOfType<TextMeshProUGUI>();

        foreach(TextMeshProUGUI text in textMeshProUGUIs)
        {
            if (text.name != "GameTitle")
                text.fontSize = Screen.width / 12;
            else
                text.fontSize = Screen.width / 7;
        }
    }

    public void loadScene (string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void exitGame()
    {
        Application.Quit();
    }

    public void updateGameDurationSetting(Slider slider)
    {
        // get value from slider and multiply by 30 to get seconds value
        //  slider should have a value range of 1-3 in increments of whole numbers
        int newVal = (int)(slider.value) * 30;
        settingsController.UpdateGameDurationSetting(newVal);
        GameDurationLabel.text = "game duration: " + newVal + "s";
    }

    public void updateGameDifficultySetting(Slider slider)
    {
        // get value from slider which should map to the GameDifficulty enum
        //  slider should have a value range of 1-3 in increments of whole numbers
        int newVal = (int)slider.value;
        settingsController.UpdateGameDifficultySetting((GameDifficulty)newVal);
        GameDifficultyLabel.text = "game difficulty: " + (GameDifficulty)newVal;
    }

    public void updateShotSensitivitySetting(Slider slider)
    {
        // get value from slider and multiply by 10 to get final value
        //  slider should have a value range of 1-10 in increments of whole numbers
        int newVal = (int)slider.value * 10;
        settingsController.UpdateShotSensitivitySetting(newVal);
        ShotSensitivityLabel.text = "shot sensitivity: " + newVal;
    }

    public void loadGameSettings()
    {
        GameDurationLabel.text = "game duration: " + settingsController.gameDuration + "s";
        GameDurationSlider.value = settingsController.gameDuration / 30;

        GameDifficultyLabel.text = "game difficulty: " + settingsController.gameDifficulty;
        GameDifficultySlider.value = (int)settingsController.gameDifficulty;

        ShotSensitivityLabel.text = "shooting sensitivity: " + settingsController.shotSensitivity;
        ShotSensitivitySlider.value = settingsController.shotSensitivity / 10;
    }

    public void loadHighScores(TextMeshProUGUI label)
    {
        string highScoreDisplay = "";

        // loop through high scores and format display text
        for (int ndx = 1; ndx <= 5; ndx++)
        {
            KeyValuePair<string, int> score = settingsController.highScores[ndx - 1];

            string initials = score.Key;
            int points = score.Value;

            highScoreDisplay += "#" + ndx + " " + initials + "\t" + points + "\n";
        }

        label.text = highScoreDisplay.TrimEnd();
    }
}
