using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SpawnBall : MonoBehaviour {

    // Maintains game object information inside Unity 3D
    [SerializeField]
    public GameObject basketBall;

    public void Spawn() {
        // Get updated AR camera position
        Vector3 newPosition = new Vector3(transform.position.x, transform.position.y - .6f, transform.position.z + 2.0f);

        // Spawn ball at new AR camera location
        Instantiate(basketBall, newPosition, Quaternion.identity);
    }
}
