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
            spr.color = new Color(255f / 255f, 0f / 255f, 0f / 255f);
        }
        else if (powerupType == PowerupType.Catch)
        {

        }
        else // if (powerupType == PowerupType.Player)
        {
            spr.color = new Color(128f / 255f, 128f / 255f, 128f / 255f);
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
                GameManager.lives++;
            }
            // Powerup has been collected, destroy self
            Destroy(gameObject);
        }
    }
}
