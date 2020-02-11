using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class MusicChange : MonoBehaviour
{
    public int BricksLeft = 66;
    public int Bricks = 66;
    private bool Started = false;
    public AudioClip Phase2 = null;

    
    // Start is called before the first frame update
    void Start()
    {
        Bricks = BricksLeft;
    }

    // Update is called once per frame
    void Update()
    {
        if(!Started)
        {
            if(Bricks/2 >= BricksLeft)
            {
                print("CHANGE");
                Started = true;
                GameObject.Find("Background").GetComponent<AudioSource>().Stop();
                GameObject.Find("Background").GetComponent<AudioSource>().clip = Phase2;
                GameObject.Find("Background").GetComponent<AudioSource>().Play();
            }
        }
    }
}
