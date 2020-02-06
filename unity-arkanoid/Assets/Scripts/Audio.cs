using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio : MonoBehaviour
{
    public string SoundName; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //put onto ball
    private void OnCollisionEnter2D(collision2D, collision)
    {
        if (OnCollisionEnter2D.gameObject.name == "Paddle")
        {
            print("paddle hit sfx played");
            AudioSource.PlayClipAtPoint(SoundName);
        }
        if (OnCollisionEnter2D.gameObject.name == "")
    }
}
