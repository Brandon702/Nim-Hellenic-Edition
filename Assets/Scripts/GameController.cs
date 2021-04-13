using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Events;
using System;

public class GameController : MonoBehaviour
{
    #region Singleton
    private static GameController _instance;

    public static GameController Instance
    {
        get
        {
            return _instance;
        }
    }

    private void Awake()
    {
        if(_instance == null)
        {
            _instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    #endregion
    
    [Header("Players")]
    public string username1;
    public string username2;

    [Header("Other variables")]
    public eState state = eState.TITLE;
    public GameObject gameOverPanel;
    [Range(0,1)]public int difficulty = 0;
    public List<GameObject> runes = new List<GameObject>();
    public List<GameObject> easyRunes = new List<GameObject>();
    public int row;
    //public Audio

    // Start is called before the first frame update
    void Start()
    {
        foreach (var obj in runes)
            obj.SetActive(false);
        difficulty = (int)GameObject.Find("DifficultySlider").GetComponent<Slider>().value;
        Console.WriteLine("Start function called");
    }

    // Update is called once per frame
    void Update()
    {
        //Game is running
        if (state == eState.GAME)
        {
            //Check if list[1] obj is enabled for game over
            if (difficulty == 0)
            {
                row = 3;
                foreach (var obj in easyRunes)
                    obj.SetActive(true);
                Debug.Log("Easy selected");
            }
            else
            {
                row = 4;
                foreach (var obj in runes)
                    obj.SetActive(true);
                Debug.Log("Hard selected");
            }
            Debug.Log("Game Activated");
        }

        if(row == 1)
        {
            //Game over
            GameOver();
        }
    }

    public void GameOver()
    {
        gameOverPanel.SetActive(true);
        foreach (var obj in runes)
            obj.SetActive(false);
    }

    public void DifficultyChanged()
    {
        difficulty = (int)GameObject.Find("DifficultySlider").GetComponent<Slider>().value;
        Console.WriteLine("difficulty: " + difficulty);
    }
}

public enum eState
{
    TITLE,
    GAME,
    PAUSE,
    OPTIONS,
    INSTRUCTIONS,
    GAMEOVER,
    CREDITS,
    MENU,
    EXITGAME
}