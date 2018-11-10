using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InitFontSizes : MonoBehaviour {

	// Use this for initialization
	void Start () {
        // get all Text objects in scene
        Text[] texts = FindObjectsOfType<Text>();
        TextMeshProUGUI[] textMeshProUGUIs = FindObjectsOfType<TextMeshProUGUI>();

        // set font sizes for all text objects in scene
        foreach (Text text in texts)
        {
            text.fontSize = Screen.width / 10;
        }

        // TODO: probably need to refactor this into an initialization script for AR scene specifically, currently this
        // TODO:   runs on both MainMenu and AR scenes (attached to EventHandler objects)

        // resizes button for AR scene
        GameObject grabButton = GameObject.Find("GrabBallRawImage");

        if (grabButton != null)
        {
            RectTransform btnTransform = grabButton.GetComponent<RectTransform>();
            btnTransform.sizeDelta = new Vector2(Screen.width / 2, Screen.width / 2);
        }

    }
}
