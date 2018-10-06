using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Note: 
// Counts the number of times ball hits ground. 
// If count > 3 issue warning for test case. 

public class BounceCount : MonoBehaviour {

    // Counters
    private int surfaceBounceCount = 0;
    private int hoopBounceCount = 0;

    private void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.name == "Surface") {

            surfaceBounceCount++;

            // Issues warning to console if ball bounces more than 3x
            if (surfaceBounceCount > 3)
                Debug.LogWarning("Test Case 'BounceCount.cs' failed!");
        }

        if(collision.gameObject.name == "hoop") {

            hoopBounceCount++;

            Debug.LogWarning("Ball has bounced off hoop " + hoopBounceCount + " times");
        }

    }


}
