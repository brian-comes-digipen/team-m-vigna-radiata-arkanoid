using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Ball : MonoBehaviour
{
    public BallState ballState = BallState.Start;
    public enum BallState { Start, Bounce, Stuck, Active = Bounce };
    Rigidbody2D rb2D;
    // Start is called before the first frame update
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        rb2D.velocity = new Vector2(50, 50);
    }

    // Update is called once per frame
    void Update()
    {
        rb2D.angularVelocity = 0;
        rb2D.velocity = rb2D.velocity.normalized * 50;
        if (transform.position.y <= -128)
        {
            Destroy(gameObject);
        }
    }
}
