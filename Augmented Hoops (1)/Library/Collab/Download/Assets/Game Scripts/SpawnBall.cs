using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SpawnBall : MonoBehaviour {

    // Maintains game object information inside Unity 3D
    [SerializeField]
    public GameObject basketBall;

    private float ballLastShot;

    public void trySpawn() {
        if (Time.time - ballLastShot > 1.0f && GameObject.Find("basketball(In-Hand)") == null)
        {
            Spawn();
        }
    }

    public void updateBallShotTimer() {
        ballLastShot = Time.time;
    }

    public void shootBall() {
        if (GameObject.Find("basketball(In-Hand)") != null)
        {

            GameController gc = GameObject.Find("GameController").GetComponent<GameController>();;
            GameObject bball = GameObject.Find("basketball(In-Hand)");
            Rigidbody rigidBody = bball.GetComponent<Rigidbody>();
            gc.ballSpawner.updateBallShotTimer();
            rigidBody.isKinematic = false;
            rigidBody.name = "basketball(Shot)";

            // set parent to Vuforia target so that ball doesn't track with canvas/phone camera
            rigidBody.transform.parent = GameObject.Find("ARCamera").transform;

            // Calculate force to ball
            rigidBody.AddForce(0, 640, 300);
        }
    }

    private void Spawn() {
        // Check to make sure ball isn't "in hand" already
        if (GameObject.Find("basketball(In-Hand)") == null)
        {
            GameObject arCamera = GameObject.Find("ARCamera");

            // Get updated AR camera position
            Vector3 newPosition = arCamera.transform.position + (arCamera.transform.forward * 4.0f) + (arCamera.transform.up * -1.0f);//new Vector3(arCamera.transform.position.x, arCamera.transform.position.y - 1.0f, arCamera.transform.position.z + 4.0f);

            Debug.Log("Cam rotation x: " + arCamera.transform.rotation.eulerAngles.x + " y: " + arCamera.transform.rotation.eulerAngles.y + "z: " + arCamera.transform.rotation.eulerAngles.z);
            // Spawn ball at new AR camera location
            GameObject newBall = Instantiate(basketBall, newPosition, arCamera.transform.rotation, arCamera.transform);
            newBall.name = "basketball(In-Hand)";
        }
        else
        {
            Debug.Log("Ball already in hand");
        }
    }
}
