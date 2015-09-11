﻿using UnityEngine;
using System.Collections;

public class Racket : MonoBehaviour {

    // up and down keys (to be set in the Inspector)
    public KeyCode up;
    public KeyCode down;
    public GameObject wallTop;
    public GameObject wallBottom;
    public bool isPlaying { get; set; }

    void Start()
    {
        isPlaying = false;
    }

    void FixedUpdate () 
    {
        if (isPlaying)
        {
            // Don't make the paddle move on the x axe
            gameObject.transform.localPosition = new Vector3(-370.0f, gameObject.transform.localPosition.y, gameObject.transform.localPosition.z);

            // Up key pressed?
            if (Input.GetKey(up))
            {
                // Don't make the paddle go out of the top boundary
                if ((gameObject.transform.localPosition.y + 32) <= (wallTop.transform.localPosition.y - 10))
                {
                    transform.Translate(new Vector2(0.0f, 5.0f));
                }
            }

            // Down key pressed?
            if (Input.GetKey(down))
            {
                // Don't make the paddle go out of the bottom boundary
                if ((gameObject.transform.localPosition.y - 32) >= (wallBottom.transform.localPosition.y + 10))
                {
                    transform.Translate(new Vector2(0.0f, -5.0f));
                }
            } 
        }
    }

    public void ResetPosition()
    {
        gameObject.transform.localPosition = new Vector3(-370f, 0f, 0f);
    }
}