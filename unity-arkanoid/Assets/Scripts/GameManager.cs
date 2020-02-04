﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static int level = 1; // Just start levels at 1, we don't need base-zero here. :/
    public static int lives = 3;
    public static int score = 0;
    public static int highScore = 50000;
    public static GameState gameState;
    public enum GameState { Title, GameInit, Game, Dead, Scores };
    public GameObject[] balls = { null, null, null };

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highScoreText;
    public TextMeshProUGUI levelText;
    public TextMeshProUGUI livesText;

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
        scoreText = GameObject.Find("Score_Text").GetComponent<TextMeshProUGUI>();
        highScoreText = GameObject.Find("HighScore_Text").GetComponent<TextMeshProUGUI>();
        livesText = GameObject.Find("Lives_Text").GetComponent<TextMeshProUGUI>();
        levelText = GameObject.Find("Level_Text").GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        if (score > highScore)
        {
            highScore = score;
        }
        highScoreText.text = $"  {score:00000}";
        scoreText.text = $"  {score:00000}";
        livesText.text = $"  {lives}";
        levelText.text = $"{level}";
    }
}
