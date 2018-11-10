using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Note:
// The following script is used as a test case to make sure 
// the rigidbody detection takes place game object mesh renderer

public class BallCollisionDetector : MonoBehaviour {

    public GameController gameController;
    private bool goingThroughHoop = false;

    // Library functiont that detects objects when scene starts
    private void OnCollisionEnter(Collision col) {

        if (col.gameObject.name == "Surface")

            // Prints out on Console anytime the 
            // Ball object hits Surface object
            Debug.Log("Ball detected surface");

        if (col.gameObject.name == "hoop")

            Debug.Log("Ball detected hoop");
    }

    private void OnTriggerEnter(Collider col)
    {

        // detect colliding with hoop and ball is coming from above the box collider (net), set going through hoop flag
        if (col.gameObject.name == "hoop" && transform.position.y > col.gameObject.GetComponent<BoxCollider>().transform.position.y)
            goingThroughHoop = true;
    }

    private void OnTriggerExit(Collider col)
    {

        // if ball just went through hoop and ball is lower than box colider (net), points++
        if (goingThroughHoop && transform.position.y < col.gameObject.GetComponent<BoxCollider>().transform.position.y)
            gameController.shotMade();
        else
            goingThroughHoop = false;
    }

}
