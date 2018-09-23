using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Note: 
// Counts the number of times ball hits ground. 
// If count > 3 issue warning for test case. 

public class BounceCount : MonoBehaviour {

    // Counter
    private int bounceCount = 0;

    private void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.name == "Surface") {
            bounceCount++;
            Debug.Log("Ball made contact with ground " + bounceCount + " times");

            // Issues warning to console if ball bounces more than 3x
            if (bounceCount > 3)
                Debug.LogWarning("Test Case 'BounceCount.cs' failed!");
        }

    }


}
