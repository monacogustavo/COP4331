using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Note:
// The following script is used as a test case to make sure 
// the rigidbody detection takes place game object mesh renderer

public class BallCollisionDetector : MonoBehaviour {


    // Library functiont that detects objects when scene starts
    private void OnCollisionEnter(Collision col) {

        if (col.gameObject.name == "Surface")

            // Prints out on Console anytime the 
            // Ball object hits Surface object
            Debug.Log("Ball detected surface");

        if (col.gameObject.name == "hoop")

            Debug.Log("Ball detected hoop");
    }

}
