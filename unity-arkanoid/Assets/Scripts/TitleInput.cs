using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity;
using UnityEditor;
using TMPro;
using UnityEngine.SceneManagement;

public class TitleInput : MonoBehaviour
{

    #region Trying to get paddle to use mouse if we have that set up
    private static TitleInput _instance;
    public static TitleInput instance
    {
        get
        {
            //if instance isn't found try to find it
            if (_instance == null)
            {
                _instance = FindObjectOfType<TitleInput>();
                DontDestroyOnLoad(_instance);
            }
            return _instance;
        }
    }

    private void Awake()
    {
        //set the singleton _instance
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(this);
        }
        else if (_instance != this)
        {
            Destroy(this);
        }
    }
    #endregion

    TextMeshProUGUI mainText;
    bool useMouse = false;
    // Start is called before the first frame update
    void Start()
    {
        if (SceneManager.GetActiveScene().name == "Start")
        {
            mainText = GameObject.Find("Text_Main").GetComponent<TextMeshProUGUI>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().name == "Start")
        {
            if (Input.GetKey(KeyCode.C))
            {
                useMouse = !useMouse;
            }
            else if (Input.GetKey(KeyCode.O))
            {
                SceneManager.LoadScene("Level1");
            }
            else if (Input.GetKey(KeyCode.P))
            {
                SceneManager.LoadScene("Level2");
            }
            else if (Input.GetKey(KeyCode.Q))
            {
                Application.Quit();
            }

            if (useMouse)
            {
                mainText.text = "O = ORIGINAL LEVEL 1\nP = PLUS CONTENT\nC = TOGGLE CONTROLS\n    (MOUSE)\nQ = QUIT GAME";
            }
            else // if (!useMouse)
            {
                mainText.text = "O = ORIGINAL LEVEL 1\nP = PLUS CONTENT\nC = TOGGLE CONTROLS\n    (ARROWS+SPACE)\nQ = QUIT GAME";
            }
        }
        else if (SceneManager.GetActiveScene().name.Contains("Level"))
        {
            GameObject.Find("Paddle").GetComponent<PlayerController>().useMouse = useMouse;
        }
    }
}
