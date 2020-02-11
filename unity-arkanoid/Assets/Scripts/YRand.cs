using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YRand : MonoBehaviour
{
    public float timery = 0;
    public float timerx = 0;
    public float delay = 1.5f;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(this.GetComponent<Rigidbody2D>().velocity.y > -4 && this.GetComponent<Rigidbody2D>().velocity.y < 4)
        {
            timery += Time.deltaTime;
            if(timery >= delay)
            {
                this.GetComponent<Rigidbody2D>().velocity = new Vector2(this.GetComponent<Rigidbody2D>().velocity.x, this.GetComponent<Rigidbody2D>().velocity.y * 3);
            }
        }else
        {
            timery = 0;
        }
        if(this.GetComponent<Rigidbody2D>().velocity.x > -4 && this.GetComponent<Rigidbody2D>().velocity.x < 4)
        {
            timerx += Time.deltaTime;
            if (timerx >= delay)
            {
                this.GetComponent<Rigidbody2D>().velocity = new Vector2(this.GetComponent<Rigidbody2D>().velocity.x * 3, this.GetComponent<Rigidbody2D>().velocity.y);
            }
        }else
        {
            timerx = 0;
        }
    }
}
