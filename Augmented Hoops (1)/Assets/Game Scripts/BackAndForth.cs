using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackAndForth : MonoBehaviour {

    public GameObject hoop;

    // Object speed
    public float movementSpeed = 2.0f;
    public float totalLength = 10.0f;

    private float elapsedTime = 0.0f;

    private bool _paused = true;
    public bool paused
    {
        get { return _paused; }
    }

    // Update is called once per frame
    void Update () {
        if (!paused)
        {
            elapsedTime += Time.deltaTime;
            // Moves object 5 spaces on x-axis back and forth calling PingPong
            hoop.transform.position = new Vector3(Mathf.PingPong(elapsedTime * movementSpeed, totalLength) -totalLength/2f, hoop.transform.position.y, hoop.transform.position.z);
        }
    }

    public void Pause()
    {
        _paused = true;
    }

    public void Unpause()
    {
        _paused = false;
    }

    public void TogglePause()
    {
        if (_paused)
            _paused = false;
        else
            _paused = true;
    }
}


