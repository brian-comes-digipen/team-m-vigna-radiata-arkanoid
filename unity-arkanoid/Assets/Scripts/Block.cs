using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    public int hitsToBreak = 1;
    private int hitsRemaining;
    // Start is called before the first frame update
    void Start()
    {
        hitsRemaining = hitsToBreak;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name.Contains("Ball"))
        {
            hitsRemaining--;
            if (hitsRemaining <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
