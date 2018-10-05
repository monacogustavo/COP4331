using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeController : MonoBehaviour {

    Rigidbody rigidBody;

    Vector2 touchStart;
    Vector2 touchEnd;
    Vector2 swipeDirection;

    float timeStart;
    float timeEnd;
    float totalTime;

    bool hasShot = false;

    [SerializeField]
    float forceX = 1f;

    [SerializeField]
    float forceY = 1f;

    [SerializeField]
    float forceZ = 40f;

    // Calls on Start
    void Start() {

        rigidBody = GetComponent<Rigidbody>();
        rigidBody.isKinematic = true;

        // disable trail until ball is shot
        GetComponent<TrailRenderer>().enabled = false;

    }

    // Calls once per frame
    private void Update() {

        // TODO: Build unit testing per conditional


        if (!hasShot && rigidBody.name != "basketball" && Input.touchCount > 0)
        {
            // Screen is touched and object is touched
            if (Input.GetTouch(0).phase == TouchPhase.Began)
            {

                // Debug message for testing
                Debug.Log("Finger touched screen");

                // Get start touch position
                touchStart = Input.GetTouch(0).position;
                
                // Get start touch time when game starts (seconds)
                timeStart = Time.time;
            }

            // Screen is touched and object is being moved
            if (Input.GetTouch(0).phase == TouchPhase.Moved)
            {
                float xMul;
                float yMul;

                // this is a multiplier/divisor to try and estimate the translation of movement in pixels (touch) to
                //   in game units so that objects will track with finger.
                if (Input.deviceOrientation == DeviceOrientation.LandscapeLeft ||
                    Input.deviceOrientation == DeviceOrientation.LandscapeRight)
                {
                    xMul = 5f;
                    yMul = 2.5f;
                }
                else
                {
                    xMul = 2.5f;
                    yMul = 5f;
                }

                // gets position of the camera
                Vector3 camPos = GameObject.Find("ARCamera").transform.position;

                Touch touchPoint = Input.GetTouch(0);
                // touchPoint coordinates are based on 0, 0 being the lower left corner of the screen, to ease translation
                //   of finger position, using code below to base coordinates 0, 0 in the center of the screen
                float xPos = touchPoint.position.x - (Screen.width / 2);
                float yPos = touchPoint.position.y - (Screen.height / 2);

                // add normalized touch position to camera position using xMul/yMul multipliers to try and translate to in game units
                Vector3 position = new Vector3(camPos.x + (xPos / (Screen.width / xMul)), camPos.y + (yPos / (Screen.height / yMul)), rigidBody.transform.position.z);

                rigidBody.transform.position = position;
            }

            // Screen touch is released and object is released
            if (Input.GetTouch(0).phase == TouchPhase.Ended)
            {

                // Debug message for testing
                Debug.Log("Finger released from screen");


                // Get end touch time when game starts (seconds)
                timeEnd = Time.time;

                // Get end touch position
                touchEnd = Input.GetTouch(0).position;

                // Get total swipe time
                totalTime = timeEnd - timeStart;

                // Get swipe direction vector
                swipeDirection = touchStart - touchEnd;

                // prevent low/no swipe from launching ball
                if (swipeDirection.magnitude < 100) {
                    Debug.Log("You gotta swing harder than that kid");
                    return;
                }

                // Turns off ball kinematic so in game gravity affects ball
                rigidBody.isKinematic = false;

                GetComponent<TrailRenderer>().enabled = true;

                rigidBody.name = "basketball(Shot)";

                // set parent to ARCamera so that ball doesn't track with canvas/phone camera
                rigidBody.transform.parent = GameObject.Find("ImageTarget").transform;

                // Calculate force to ball
                rigidBody.AddForce((forceX * forceY) * (-swipeDirection.x), (forceX * forceY) * (-swipeDirection.y), forceZ / totalTime);
                hasShot = true;
            }
        }
    }
}
