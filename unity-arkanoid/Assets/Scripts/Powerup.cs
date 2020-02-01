using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour
{
    public static PowerupType powerupType;
    public enum PowerupType { Laser, Enlarge, Catch, Slow, Break, Disruption, Player };
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name.Contains("Player"))
        {
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
                GameManager.Lives++;
            }
            // Powerup has been collected, destroy self
            Destroy(gameObject);
        }
    }
}
