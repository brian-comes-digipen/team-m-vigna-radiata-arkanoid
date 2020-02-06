using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class MusicLoop : MonoBehaviour
{
    public bool Started = false;

    private RandomContainer randomC;

    // Start is called before the first frame update
    void Start()
    {
        randomC = GameObject.FindObjectOfType(typeof(RandomContainer)) as RandomContainer;
    }

    // Update is called once per frame
    void Update()
    {
        if (Started)
        {
            if(randomC != null)
            {

            }
        }
    }
}
