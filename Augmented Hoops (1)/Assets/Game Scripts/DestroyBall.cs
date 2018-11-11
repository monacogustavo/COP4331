using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBall : MonoBehaviour {

    private int numOfBounces = 0;

    private void OnCollisionEnter(Collision collision) {

        if (collision.gameObject.name == "Surface") {
            numOfBounces++;
            if (numOfBounces >= 3)
                Destroy(gameObject);
        }
        
    }



}
