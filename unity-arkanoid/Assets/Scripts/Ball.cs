using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Ball : MonoBehaviour
{
    public bool offScreen = false;
    public bool shouldStickToPaddle = true;
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
            offScreen = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerController>() != null && collision.gameObject.GetComponent<PlayerController>().paddleType == PlayerController.PaddleType.Sticky)
        {
            StartCoroutine(StickPaddle());
        }
    }

    // Makes the ball follow/stick the paddle for a given number of seconds
    public IEnumerator StickPaddleThenLaunchAfterSeconds(float s)
    {
        StartCoroutine(StickPaddle());
        yield return new WaitForSeconds(s);
        shouldStickToPaddle = false;
        StopCoroutine(StickPaddle());
        StartCoroutine(LaunchBall());
    }

    public IEnumerator StickPaddle()
    {
        shouldStickToPaddle = true;
        while (shouldStickToPaddle)
        {
            ballState = BallState.Stuck;
            transform.position = (Vector2)GameObject.Find("Paddle").transform.position + new Vector2(3f, 5.5f);
            rb2D.velocity = Vector2.zero;
            yield return new WaitForEndOfFrame();
        }
        yield return null;
    }

    public IEnumerator LaunchBall()
    {
        ballState = BallState.Active;
        shouldStickToPaddle = false;
        StopCoroutine(StickPaddle());
        System.Random r = new System.Random();
        if (r.Next(0, 2) == 0)
        {
            rb2D.velocity = new Vector2(ballSpeed, ballSpeed);
        }
        else
        {
            rb2D.velocity = new Vector2(-ballSpeed, ballSpeed);
        }
        GameObject.Find("Paddle").GetComponent<PlayerController>().paddleType = PlayerController.PaddleType.Normal;
        yield return null;
    }
}
