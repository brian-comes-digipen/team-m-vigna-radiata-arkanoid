using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public bool useMouse = false;
    public PaddleType paddleType = PaddleType.Normal;
    public enum PaddleType { Normal, Enlarge, Laser, Sticky }
    public float leftXBoundary = -96.5f;
    public float rightXBoundary = 47.5f;
    public float speedInPixelsPerFrame = 2;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (!useMouse)
        {
            if (Input.GetKey(KeyCode.LeftArrow) && transform.position.x != -104.5)
            {
                transform.position -= (Vector3)new Vector2(speedInPixelsPerFrame, 0);
            }
            else if (Input.GetKey(KeyCode.RightArrow) && transform.position.x != 39.5)
            {
                transform.position += (Vector3)new Vector2(speedInPixelsPerFrame, 0);
            }
        }
        else
        {
            // Add mouse movement
            transform.position = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, transform.position.y);
        }

        if (transform.position.x > 47.5f)
        {
            transform.position = new Vector2(47.5f, transform.position.y);
        }
        if (transform.position.x < -96.5f)
        {
            transform.position = new Vector2(-96.5f, transform.position.y);
        }
    }
}
