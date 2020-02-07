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

    public SpriteRenderer LeftEnd;
    public SpriteRenderer RightEnd;

    

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

        if (transform.position.x > 47.5f)
        {
            transform.position = new Vector2(47.5f, transform.position.y);
        }
        if (transform.position.x < -96.5f)
        {
            transform.position = new Vector2(-96.5f, transform.position.y);
        }

        if (paddleType == PaddleType.Laser)
        {
            LeftEnd.color = Color.black;
            RightEnd.color = Color.black;
        }
        else
        {
            LeftEnd.color = new Color(181, 49, 33, 255);
            RightEnd.color = new Color(181, 49, 33, 255);
        }

        //Kyle
        if (paddleType == PaddleType.Enlarge)
        {
            print(LeftPiece.transform.localPosition.x + 8);
            print(RightPiece.transform.localPosition.x);

            if (LeftPiece.transform.localPosition.x + 8 == RightPiece.transform.localPosition.x)
            {
                LeftEndPiece.transform.localScale.Set(LeftEndPiece.transform.localScale.x - 200, LeftEndPiece.transform.localScale.y, LeftEndPiece.transform.localScale.z);
                LeftPiece.transform.localPosition.Set(LeftPiece.transform.localPosition.x - 200, LeftPiece.transform.localPosition.y, LeftPiece.transform.localPosition.z);
                RightPiece.transform.localPosition.Set(RightPiece.transform.localPosition.x + 200, RightPiece.transform.localPosition.y, RightPiece.transform.localPosition.z);
                RightEndPiece.transform.localPosition.Set(RightEndPiece.transform.localPosition.x + 200, RightEndPiece.transform.localPosition.y, RightEndPiece.transform.localPosition.z);

                print("Enlarged");

                var Capsule = GetComponent<CapsuleCollider2D>();

                this.GetComponent<CapsuleCollider2D>().size.Set(48, 8);
                GameObject.Find("Paddle").GetComponent<CapsuleCollider2D>().size.Set(48, 8);
                Capsule.size.Set(48, 8);
            }
        }
        else
        {
            if (LeftPiece.transform.position.x + 8 != RightPiece.transform.position.x)
            {
                LeftEndPiece.transform.localPosition.Set(LeftEndPiece.transform.localPosition.x + 8, LeftEndPiece.transform.localPosition.y, LeftEndPiece.transform.localPosition.z);
                LeftPiece.transform.localPosition.Set(LeftPiece.transform.localPosition.x + 8, LeftPiece.transform.localPosition.y, LeftPiece.transform.localPosition.z);
                RightPiece.transform.localPosition.Set(RightPiece.transform.localPosition.x - 8, RightPiece.transform.localPosition.y, RightPiece.transform.localPosition.z);
                RightEndPiece.transform.localPosition.Set(RightEndPiece.transform.localPosition.x - 8, RightEndPiece.transform.localPosition.y, RightEndPiece.transform.localPosition.z);

                print("Shrink");

                var Capsule = GetComponent<CapsuleCollider2D>();

                this.GetComponent<CapsuleCollider2D>().size.Set(48, 8);
                GameObject.Find("Paddle").GetComponent<CapsuleCollider2D>().size.Set(48, 8);
                Capsule.size.Set(48, 8);
            }
        }
        //End

        if (paddleType == PaddleType.Sticky)
        {
            this.GetComponent<Material>();
        }
        else
        {

        }
    }
}
