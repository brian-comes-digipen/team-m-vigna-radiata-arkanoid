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

    public bool canFireLasers = false;

    public SpriteRenderer LeftEnd;
    public SpriteRenderer RightEnd;

    public GameObject laserProjectilePrefab;


    // Part of Kyle's attempt at trying to get extension powerup to work
    public GameObject LeftEndPiece;
    public GameObject LeftPiece;
    public GameObject RightPiece;
    public GameObject RightEndPiece;

    Rigidbody2D rb2D;
    // Start is called before the first frame update
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
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
            transform.position = new Vector2((float)Math.Round(Camera.main.ScreenToWorldPoint(Input.mousePosition).x * 2, MidpointRounding.AwayFromZero) / 2, transform.position.y);
        }

        if (paddleType == PaddleType.Enlarge)
        {
            if (transform.position.x > rightXBoundary - 8)
            {
                transform.position = new Vector2(rightXBoundary - 8, transform.position.y);
            }
            if (transform.position.x < leftXBoundary + 8)
            {
                transform.position = new Vector2(leftXBoundary + 8, transform.position.y);
            }
        }
        else // if (paddleType != PaddleType.Enlarge)
        {
            if (transform.position.x > rightXBoundary)
            {
                transform.position = new Vector2(rightXBoundary, transform.position.y);
            }
            if (transform.position.x < leftXBoundary)
            {
                transform.position = new Vector2(leftXBoundary, transform.position.y);
            }
        }

        if (paddleType == PaddleType.Laser)
        {
            LeftEnd.color = Color.red;
            RightEnd.color = Color.red;

            if (Input.GetKey(KeyCode.Space) || (useMouse && Input.GetMouseButton(0)))
            {
                StartCoroutine(FireLasers());
            }
        }
        else if (paddleType == PaddleType.Sticky)
        {
            LeftEnd.color = Color.blue;
            RightEnd.color = Color.blue;
            GameObject.Find("Ball").GetComponent<Ball>().shouldStickToPaddle = true;
            if (Input.GetKey(KeyCode.Space) && GameObject.Find("Ball").GetComponent<Ball>().ballState == Ball.BallState.Stuck)
            {
                GameObject.Find("Ball").GetComponent<Ball>().shouldStickToPaddle = false;
                StopCoroutine(GameObject.Find("Ball").GetComponent<Ball>().StickPaddle());
                StartCoroutine(GameObject.Find("Ball").GetComponent<Ball>().LaunchBall());
            }
        }
        else if (paddleType == PaddleType.Sticky)
        {
            LeftEnd.color = Color.green;
            RightEnd.color = Color.green;
        }
        else
        {
            LeftEnd.color = new Color(181f / 255f, 49f / 255f, 33f / 255f, 255f / 255f);
            RightEnd.color = new Color(181f / 255f, 49f / 255f, 33f / 255f, 255f / 255f);

            GameObject.Find("Ball").GetComponent<Ball>().shouldStickToPaddle = false;
        }

        #region Kyle's Janky Extension Code
        if (paddleType == PaddleType.Enlarge)
        {
            print(LeftPiece.transform.localPosition.x + 8);
            print(RightPiece.transform.localPosition.x);

            if (LeftPiece.transform.localPosition.x + 8 == RightPiece.transform.localPosition.x)
            {
                LeftEndPiece.transform.localPosition = new Vector3(LeftEndPiece.transform.localPosition.x - 8, LeftEndPiece.transform.localPosition.y, LeftEndPiece.transform.localPosition.z);
                LeftPiece.transform.localPosition = new Vector3(LeftPiece.transform.localPosition.x - 8, LeftPiece.transform.localPosition.y, LeftPiece.transform.localPosition.z);
                RightPiece.transform.localPosition = new Vector3(RightPiece.transform.localPosition.x + 8, RightPiece.transform.localPosition.y, RightPiece.transform.localPosition.z);
                RightEndPiece.transform.localPosition = new Vector3(RightEndPiece.transform.localPosition.x + 8, RightEndPiece.transform.localPosition.y, RightEndPiece.transform.localPosition.z);

                print("Enlarged");

                GameObject.Find("Paddle").GetComponent<CapsuleCollider2D>().size = new Vector2(48, 8);
            }
        }
        else
        {
            if (LeftPiece.transform.position.x + 8 != RightPiece.transform.position.x)
            {
                LeftEndPiece.transform.localPosition = new Vector3(LeftEndPiece.transform.localPosition.x + 8, LeftEndPiece.transform.localPosition.y, LeftEndPiece.transform.localPosition.z);
                LeftPiece.transform.localPosition = new Vector3(LeftPiece.transform.localPosition.x + 8, LeftPiece.transform.localPosition.y, LeftPiece.transform.localPosition.z);
                RightPiece.transform.localPosition = new Vector3(RightPiece.transform.localPosition.x - 8, RightPiece.transform.localPosition.y, RightPiece.transform.localPosition.z);
                RightEndPiece.transform.localPosition = new Vector3(RightEndPiece.transform.localPosition.x - 8, RightEndPiece.transform.localPosition.y, RightEndPiece.transform.localPosition.z);

                print("Shrink");

                GameObject.Find("Paddle").GetComponent<CapsuleCollider2D>().size = new Vector2(48, 8);
            }
        }
        #endregion
    }

    IEnumerator FireLasers()
    {
        if (canFireLasers)
        {
            Instantiate(laserProjectilePrefab, new Vector3(transform.position.x - 13.5f, transform.position.y + 11.5f), new Quaternion(0, 0, 0, 0));
            Instantiate(laserProjectilePrefab, new Vector3(transform.position.x + 13.5f, transform.position.y + 11.5f), new Quaternion(0, 0, 0, 0));
            StartCoroutine(LaserCooldown());
            yield return null;
        }
        yield return null;
    }

    IEnumerator LaserCooldown()
    {
        canFireLasers = false;
        yield return new WaitForSeconds(.5f);
        canFireLasers = true;
        yield return null;
    }
}
