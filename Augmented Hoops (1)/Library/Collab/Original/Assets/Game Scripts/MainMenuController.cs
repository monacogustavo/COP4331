using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// this file will control all actions from the main menu (initiating game, viewing high scores panel, etc)
public class MainMenuController : MonoBehaviour {

    public void loadScene (string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
