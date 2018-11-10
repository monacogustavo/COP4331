using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutOfBounds : MonoBehaviour {

    public GameObject destroyObject;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "OutOfBounds")
        {
            Destroy(destroyObject);
        }
    }
}
