using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Audio : MonoBehaviour
{
    private RandomContainer randomC;
    // Start is called before the first frame update
    void Start()
    {
        randomC = GameObject.FindObjectOfType(typeof(RandomContainer)) as RandomContainer;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //put onto ball
    private void OnCollisionEnter2D(Collider2D collider2D)
    {
        if (collider2D.gameObject.name == "Paddle")
        {
            print("paddle hit sfx played");
            randomC.PlaySound(0);
        }
        if (collider2D.gameObject.name == "Wall")
        {
            print("wall hit sfx played");
            randomC.PlaySound(1);
        }
    }
}
