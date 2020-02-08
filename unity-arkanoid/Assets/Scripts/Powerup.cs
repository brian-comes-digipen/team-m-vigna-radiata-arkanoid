using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour
{
    public enum PowerupType { Laser, Catch, Player, Extend };
    public PowerupType powerupType = PowerupType.Laser;
    public float fallSpeed = -50f;

    Rigidbody2D rb2D;
    SpriteRenderer spr;
    // Start is called before the first frame update
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        rb2D.velocity = new Vector2(0, fallSpeed);
        spr = GetComponent<SpriteRenderer>();
        if (powerupType == PowerupType.Laser)
        {
            spr.color = Color.red;
        }
        else if (powerupType == PowerupType.Catch)
        {
            spr.color = Color.green;
        }
        else if (powerupType == PowerupType.Extend)
        {
            spr.color = Color.blue;
        }
        else // if (powerupType == PowerupType.Player)
        {
            spr.color = Color.gray;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y <= -128)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Paddle")
        {
            print("powerup touched player");
            // Modify the player, ball, or play area based on the powerup type, quite self-explanitory
            if (powerupType == PowerupType.Laser)
            {
                collision.gameObject.GetComponent<PlayerController>().paddleType = PlayerController.PaddleType.Laser;
                collision.gameObject.GetComponent<PlayerController>().canFireLasers = true;
            }
            else if (powerupType == PowerupType.Catch)
            {
                collision.gameObject.GetComponent<PlayerController>().paddleType = PlayerController.PaddleType.Sticky;
            }
            else if (powerupType == PowerupType.Extend)
            {
                collision.gameObject.GetComponent<PlayerController>().paddleType = PlayerController.PaddleType.Enlarge;
            }
            else // if (powerupType == PowerupType.Player)
            {
                collision.gameObject.GetComponent<PlayerController>().paddleType = PlayerController.PaddleType.Normal;
                GameManager.lives++;
            }
            // Powerup has been collected, destroy self
            Destroy(gameObject);
        }
    }
}
