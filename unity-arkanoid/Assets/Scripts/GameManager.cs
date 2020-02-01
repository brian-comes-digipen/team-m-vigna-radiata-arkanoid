using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static int Level = 1; // Just start levels at 1, we don't need base-zero here. :/
    public static int Lives = 3;
    public static int Score = 0;
    public static GameState gameState;
    public enum GameState { Title, Game, Dead, Scores };

    #region GameManager Instance Stuff
    private static GameManager _instance;
    public static GameManager instance
    {
        get
        {
            //if instance isn't found try to find it
            if (_instance == null)
            {
                _instance = FindObjectOfType<GameManager>();
                DontDestroyOnLoad(_instance);
            }
            return _instance;
        }
    }
    #endregion

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

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
