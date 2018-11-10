using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameDifficulty
{
    easy = 1,
    medium,
    hard
}

public class SettingsController : MonoBehaviour
{

    // keys to be used across the application to save/load state between game sessions
    private string gameDurationSettingKey = "gameDurationSetting";
    private string gameDifficultySettingKey = "gameDifficultySetting";
    private string shotSensitivitySettingKey = "shotSensitivitySetting";
    private string highScoresSettingKey = "highScores";

    private int _gameDuration;
    public int gameDuration
    {
        get { return _gameDuration; }
    }

    private GameDifficulty _gameDifficulty;
    public GameDifficulty gameDifficulty
    {
        get { return _gameDifficulty; }
    }

    private int _shotSensitivity;
    public int shotSensitivity
    {
        get { return _shotSensitivity; }
    }

    private KeyValuePair<string, int>[] _highScores;
    public KeyValuePair<string, int>[] highScores
    {
        get { return _highScores; }
    }

    // load all settings or default values if none found
    void Start () {
        _gameDifficulty = (GameDifficulty)PlayerPrefs.GetInt(gameDifficultySettingKey, (int)GameDifficulty.easy);
        _gameDuration = PlayerPrefs.GetInt(gameDurationSettingKey, 30);
        _shotSensitivity = PlayerPrefs.GetInt(shotSensitivitySettingKey, 50);
        loadHighScores("---,0;---,0;---,0;---,0;---,0");
	}

    private void loadHighScores(string defaultValue)
    {
        string[] hiScores = PlayerPrefs.GetString(highScoresSettingKey, defaultValue).Split(";".ToCharArray(), System.StringSplitOptions.RemoveEmptyEntries);
        _highScores= new KeyValuePair<string, int>[hiScores.Length];

        Debug.Log(hiScores.Length);
        for (int i = 0; i < hiScores.Length; i++)
        {
            string[] entry = hiScores[i].Split(",".ToCharArray());

            _highScores[i] = new KeyValuePair<string, int>(entry[0], int.Parse(entry[1]));
        }
    }

    public void UpdateGameDifficultySetting(GameDifficulty difficulty)
    {
        PlayerPrefs.SetInt(gameDifficultySettingKey, (int)difficulty);
        _gameDifficulty = difficulty;
    }

    public void UpdateGameDurationSetting(int duration)
    {
        PlayerPrefs.SetInt(gameDurationSettingKey, duration);
        _gameDuration = duration;
    }

    public void UpdateShotSensitivitySetting(int sensitivity)
    {
        PlayerPrefs.SetInt(shotSensitivitySettingKey, sensitivity);
        _shotSensitivity = sensitivity;
    }

    public bool NewHighScoreCheck(int points)
    {
        foreach(KeyValuePair<string, int> score in highScores)
        {
            if (points > score.Value)
            {
                return true;
            }
        }

        return false;
    }

    public void AddNewHighScore(string initials, int points)
    {
        KeyValuePair<string, int>[] newHighScores = new KeyValuePair<string, int>[highScores.Length];

        int offset = 0;
        for (int i = 0; i < highScores.Length; i++)
        {
            KeyValuePair<string, int> score = highScores[i];

            if (points > score.Value && offset == 0)
            {
                initials = initials.ToUpper();
                newHighScores[i] = new KeyValuePair<string, int>(initials, points);
                offset = 1;
            }
            else
            {
                newHighScores[i] = highScores[i - offset];
            }
        }

        string newHighScoreSetting = "";
        foreach (KeyValuePair<string, int> score in newHighScores)
        {
            newHighScoreSetting += score.Key + "," + score.Value + ";";
        }

        PlayerPrefs.SetString(highScoresSettingKey, newHighScoreSetting);
    }
}
