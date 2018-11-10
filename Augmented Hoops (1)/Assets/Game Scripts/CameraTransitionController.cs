using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTransitionController : MonoBehaviour {

    private float smoothTime = .3f;
    private float rotationSpeed = .1f;
    private Vector3 velocity = Vector3.zero;

    public GameObject mainMenuPanel;
    public GameObject settingsPanel;
    public GameObject highScoresPanel;

    private Vector3 mainMenuPosition = new Vector3(-3, 2.25f, -10);
    private Quaternion mainMenuRotation = Quaternion.Euler(new Vector3 (0, 10, 0));

    private Vector3 settingsPosition = new Vector3(1, 1.75f, -3);
    private Quaternion settingsRotation = Quaternion.Euler(new Vector3(-30, -30, 0));

    private Vector3 highScoresPosition = new Vector3(0, 1, -5);
    private Quaternion highScoresRotation = Quaternion.Euler(new Vector3(-50, 0, 0));

    // manages camera transitions based on active panel in scene, called every frame
    void Update () {

        // this section of code automatically animates the shooting of basketballs in the background
        GameObject basketBall = GameObject.Find("basketball");
        Rigidbody rb;

        // main menu active and basketball for this panel not currently instantiated (prevent multiple balls)
        if (mainMenuPanel.activeInHierarchy && GameObject.Find("basketball(MainMenuPanel)") == null)
        {
            // instantiate ball, enable physics/gravity and apply force to ball
            // ** editing numbers will affect shot trajectory **
            basketBall = Instantiate(basketBall, new Vector3(-4, 0, -11), Quaternion.identity);
            rb = basketBall.GetComponent<Rigidbody>();
            rb.isKinematic = false;
            rb.AddForce(110, 560, 300);

            // rename ball so that it can be identified in scene
            basketBall.name = "basketball(MainMenuPanel)";
        }
        else if (highScoresPanel.activeInHierarchy && GameObject.Find("basketball(HighScoresPanel)") == null)
        {
            // instantiate ball, enable physics/gravity and apply force to ball
            // ** editing numbers will affect shot trajectory **
            basketBall = Instantiate(basketBall, new Vector3(0, 4, -8), Quaternion.identity);
            rb = basketBall.GetComponent<Rigidbody>();
            rb.isKinematic = false;
            rb.AddForce(0, 580.5f, 160);

            // rename ball so that it can be identified in scene
            basketBall.name = "basketball(HighScoresPanel)";
        }
        else if (settingsPanel.activeInHierarchy && GameObject.Find("basketball(SettingsPanel)") == null)
        {
            // instantiate ball, enable physics/gravity and apply force to ball
            // ** editing numbers will affect shot trajectory **
            basketBall = Instantiate(basketBall, new Vector3(8, 2, -1.5f), Quaternion.identity);
            rb = basketBall.GetComponent<Rigidbody>();
            rb.isKinematic = false;
            rb.AddForce(-200, 510, 10);

            // rename ball so that it can be identified in scene
            basketBall.name = "basketball(SettingsPanel)";
        }

        // this section of code handles transitioning the camera when active panel changes
        if (mainMenuPanel.activeInHierarchy)
        {
            // camera has reached desired location
            if (transform.position == mainMenuPosition && transform.rotation == mainMenuRotation)
                return;

            // transition camera position and rotation over time
            transform.position = Vector3.SmoothDamp(transform.position, mainMenuPosition, ref velocity, smoothTime);

            transform.rotation = Quaternion.Slerp(transform.rotation, mainMenuRotation, rotationSpeed);
        }
        else if (settingsPanel.activeInHierarchy)
        {
            // camera has reached desired location
            if (transform.position == settingsPosition && transform.rotation == settingsRotation)
                return;

            // transition camera position and rotation over time
            transform.position = Vector3.SmoothDamp(transform.position, settingsPosition, ref velocity, smoothTime);

            transform.rotation = Quaternion.Slerp(transform.rotation, settingsRotation, rotationSpeed);
        }
        else if (highScoresPanel.activeInHierarchy)
        {
            // camera has reached desired location
            if (transform.position == highScoresPosition && transform.rotation == highScoresRotation)
                return;

            // transition camera position and rotation over time
            transform.position = Vector3.SmoothDamp(transform.position, highScoresPosition, ref velocity, smoothTime);

            transform.rotation = Quaternion.Slerp(transform.rotation, highScoresRotation, rotationSpeed);
        }
    }
}
