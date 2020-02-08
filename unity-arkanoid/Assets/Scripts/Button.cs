using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Button : MonoBehaviour
{
    public string LevelName;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void ButtonScene()
    {
        if (Input.GetKeyDown(KeyCode.O) || Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene("Level1");
        }
        if (Input.GetKeyDown(KeyCode.P))
        {
            SceneManager.LoadScene("Level2");
        }
    }
}
