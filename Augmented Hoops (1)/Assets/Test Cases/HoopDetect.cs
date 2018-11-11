using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoopDetect : MonoBehaviour {

    // Add to ball to detect hoop object
    private void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.name == "hoop") {
            Debug.Log("Ball detects hoop");
        } 
    }
}
