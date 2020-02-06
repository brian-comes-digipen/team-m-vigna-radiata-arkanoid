using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour
{
    public enum PowerupType { Laser, Enlarge, Catch, Slow, Break, Disruption, Player };
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
            spr.color = new Color(255, 0, 0);
        }
        else if (powerupType == PowerupType.Enlarge)
        {
            spr.color = new Color(0, 0, 255);
        }
        else if (powerupType == PowerupType.Catch)
        {
            
        }
        else if (powerupType == PowerupType.Break)
        {
            spr.color = new Color(255, 0, 255);
        }
        else if (powerupType == PowerupType.Disruption)
        {
            spr.color = new Color(0, 255, 255);
        }
        else // if (powerupType == PowerupType.Player)
        {
            spr.color = new Color(128, 128, 128);
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
            }
            else if (powerupType == PowerupType.Enlarge)
            {
                collision.gameObject.GetComponent<PlayerController>().paddleType = PlayerController.PaddleType.Enlarge;
            }
            else if (powerupType == PowerupType.Catch)
            {
                collision.gameObject.GetComponent<PlayerController>().paddleType = PlayerController.PaddleType.Sticky;
            }
            else if (powerupType == PowerupType.Break)
            {
                // Open gate on right side of stage, allow level skipping
            }
            else if (powerupType == PowerupType.Disruption)
            {
                // Duplicate ball twice from currently active ball
            }
            else // if (powerupType == PowerupType.Player)
            {
                GameManager.lives++;
            }
            // Powerup has been collected, destroy self
            Destroy(gameObject);
        }
    }
}
