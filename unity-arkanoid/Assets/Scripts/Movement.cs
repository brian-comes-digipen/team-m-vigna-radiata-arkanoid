using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public KeyCode upKey = KeyCode.W;
    public KeyCode leftKey = KeyCode.A;
    public KeyCode downKey = KeyCode.S;
    public KeyCode rightKey = KeyCode.D;

    public float speed = 0.05f;
    public Vector2 Move;
    public float reverse = 5;

    // Update is called once per frame
    void Update()
    {
        Move = new Vector2(0, 0);

        if(Input.GetKey(upKey))
        {
            Move += new Vector2(0, 1);
        }
        if (Input.GetKey(leftKey))
        {
            Move += new Vector2(-1, 0);
        }
        if (Input.GetKey(downKey))
        {
            Move += new Vector2(0, -1);
        }
        if (Input.GetKey(rightKey))
        {
            Move += new Vector2(1, 0);
        }

        Move.Normalize();

        if ((Move.x > 0 && this.gameObject.GetComponent<Rigidbody>().velocity.x < 0) || (Move.x < 0 && this.gameObject.GetComponent<Rigidbody>().velocity.x > 0))
        {
            Move = new Vector2(Move.x * reverse, Move.y);
        }

        if ((Move.y > 0 && this.gameObject.GetComponent<Rigidbody>().velocity.y < 0) || (Move.y < 0 && this.gameObject.GetComponent<Rigidbody>().velocity.y > 0))
        {
            Move = new Vector2(Move.x, Move.y * reverse);
        }

        if (Move.x != 0 || Move.y != 0)
        {
            this.gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(Move.x * speed, Move.y * speed, 0));
        }else
        {
            this.gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(this.gameObject.GetComponent<Rigidbody>().velocity.x * -0.85f, this.gameObject.GetComponent<Rigidbody>().velocity.y * -0.85f, 0));
        }
    }
}
