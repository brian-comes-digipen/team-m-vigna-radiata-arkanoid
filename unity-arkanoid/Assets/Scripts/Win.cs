using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Win : MonoBehaviour
{
    public int BricksLeft = 66;
    public int Bricks = 66;
    public string newLevel = null;


    // Start is called before the first frame update
    void Start()
    {
        Bricks = BricksLeft;
    }

    // Update is called once per frame
    void Update()
    {
        if(BricksLeft <= 0)
        {
            SceneManager.LoadScene(newLevel);
        }
    }
}
