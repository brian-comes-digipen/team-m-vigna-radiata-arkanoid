using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Ball : MonoBehaviour
{
    public BallState ballState = BallState.Start;
    public enum BallState { Start, Bounce, Stuck, Active = Bounce };

    public float ballSpeed = 100;
    Rigidbody2D rb2D;
    // Start is called before the first frame update
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();

        StartCoroutine(StickPaddleThenLaunchAfterSeconds(2.5f));
    }

    // Update is called once per frame
    void Update()
    {
        rb2D.angularVelocity = 0;
        rb2D.velocity = new Vector2(rb2D.velocity.normalized.x * ballSpeed, rb2D.velocity.normalized.y * ballSpeed);
        if (transform.position.y <= -128)
        {
            Destroy(gameObject);
        }
    }

    // Makes the ball follow/stick the paddle for a given number of seconds
    IEnumerator StickPaddleThenLaunchAfterSeconds(float s)
    {
        float elapsed = 0;
        while (elapsed <= s)
        {
            transform.position = (Vector2)GameObject.Find("Paddle").transform.position + new Vector2(3, 5.5f);
            yield return new WaitForSeconds(1.0f / 120.0f); // Wait for one half frame (assuming 60fps is constant)
            elapsed += 1.0f / 120.0f;
        }

        System.Random r = new System.Random();
        if (r.Next(0, 2) == 0)
        {
            rb2D.velocity = new Vector2(ballSpeed, ballSpeed);
        }
        else
        {
            rb2D.velocity = new Vector2(-ballSpeed, ballSpeed);
        }
    }
}
