using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundsDetect : MonoBehaviour {

    // Attach to ball for testing
    // Detects out of bounds object for testing
    private void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.name == "OutOfBounds") {
            Debug.Log("Ball detects out of bounds");
        }
    }

}
