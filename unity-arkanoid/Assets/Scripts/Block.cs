using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    public int hitsToBreak = 1;
    public BlockType blockType = BlockType.White;

    // Gold blocks are indestructable
    public enum BlockType { White = 50, Orange = 60, Cyan = 70, Green = 80, Red = 90, Blue = 100, Magenta = 110, Yellow = 120, Silver = 1, Gold = -1 };
    public GameObject powerupPrefab = null;
    private int hitsRemaining;
    // Start is called before the first frame update
    void Start()
    {
        if (blockType == BlockType.Silver)
        {
            int extraSilverPoints = 0;
            for (int i = 0; i < GameManager.level; ++i)
            {
                if (GameManager.level % 8 == 0)
                {
                    extraSilverPoints = i;
                }
            }
            hitsToBreak = 2 + extraSilverPoints;
        }
        hitsRemaining = hitsToBreak;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name.Contains("Ball") || collision.gameObject.name.Contains("Laser"))
        {
            if (blockType != BlockType.Gold)
            {
                hitsRemaining--;
                if (hitsRemaining <= 0)
                {
                    if (blockType <= BlockType.Yellow && blockType >= BlockType.White)
                    {
                        GameManager.score += (int)blockType;
                    }
                    else //if (blockType == BlockType.Silver)
                    {
                        GameManager.score += GameManager.level * 50;
                    }

                    System.Random r = new System.Random();
                    if (r.Next(0, 100) <= 27)
                    {
                        GameObject spawnedPowerup = Instantiate(powerupPrefab);
                        int powerID = r.Next(0, 5);
                        spawnedPowerup.GetComponent<Powerup>().powerupType = (Powerup.PowerupType)powerID;
                        spawnedPowerup.transform.position = transform.position;
                    }

                    Destroy(gameObject);
                }
            }

            //if (!(GameObject.FindGameObjectsWithTag("Ball").Length > 1))
            //{
            //    // Spawn powerup
            //}
        }
    }
}
