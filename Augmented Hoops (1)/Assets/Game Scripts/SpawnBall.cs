using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SpawnBall : MonoBehaviour {

    // Maintains game object information inside Unity 3D
    [SerializeField]
    public GameObject basketBall;

    public void Spawn() {
        // Check to make sure ball isn't "in hand" already
        if (GameObject.Find("basketball(In-Hand)") == null)
        {
            // Get updated AR camera position
            Vector3 newPosition = new Vector3(transform.position.x, transform.position.y - 1.0f, transform.position.z + 4.0f);

            // Spawn ball at new AR camera location
            GameObject newBall = Instantiate(basketBall, newPosition, Quaternion.identity);
            newBall.name = "basketball(In-Hand)";
        }
        else
        {
            // uncomment for shooting ability from PC
            //Rigidbody rb = GameObject.Find("basketball(In-Hand)").GetComponent<Rigidbody>();
            //rb.isKinematic = false;
            //rb.name = "basketball(Shot)";
            //rb.transform.parent = GameObject.Find("ImageTarget").transform;
            //rb.AddForce(0, 500, 250);
            Debug.Log("Ball already in hand");
        }
    }
}
