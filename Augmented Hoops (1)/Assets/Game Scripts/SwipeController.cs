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

    }

    // Calls once per frame
    private void Update() {

        // TODO: Build unit testing per conditional

        //if (Input.GetMouseButtonDown(0)) {
            //Debug.Log(GameObject.Find("ImageTarget").name);
            //rigidBody.transform.parent = GameObject.Find("ImageTarget").transform;
        //}


        if (!hasShot && rigidBody.name != "basketball")
        {
            // Screen is touched and object is touched
            if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
            {

                // Debug message for testing
                Debug.Log("Finger touched screen");

                // Get start touch position
                touchStart = Input.GetTouch(0).position;


                // Get start touch time when game starts (seconds)
                timeStart = Time.time;
            }

            // Screen touch is released and object is released
            if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)
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

                // Calculate force to ball
                rigidBody.name = "basketball(Shot)";
                rigidBody.transform.parent = GameObject.Find("ImageTarget").transform;
                rigidBody.AddForce((forceX * forceY) * (-swipeDirection.x), (forceX * forceY) * (-swipeDirection.y), forceZ / totalTime);
                hasShot = true;
            }
        }
    }
}
