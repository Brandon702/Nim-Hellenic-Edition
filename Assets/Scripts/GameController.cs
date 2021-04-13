using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Events;
using System;
using System.Linq;

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
    string username1 = "Player";
    string username2 = "Jonathan";

    [Header("Other variables")]
    public eState state = eState.TITLE;
    public GameObject gameOverPanel;
    [Range(0,1)]public int difficulty = 0;
    public List<GameObject> runes = new List<GameObject>();
    public List<GameObject> easyRunes = new List<GameObject>();
    List<GameObject> allRunes = new List<GameObject>();
    public System.Random rand = new System.Random();
    public bool forceOnce = true;

    int selectedRow=0;
    public InputSystem input;

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
                selectedRow = 3;
                foreach (var obj in easyRunes)
                    obj.SetActive(true);
                //Debug.Log("Easy selected");
            }
            else
            {
                selectedRow = 4;
                foreach (var obj in runes)
                    obj.SetActive(true);
                //Debug.Log("Hard selected");
            }
            //Debug.Log("Game Activated"); 
            if(forceOnce == true)
            {
                Debug.Log("\nUser1: " + username1 + "\nUser2: "+ username2);
                GameSession();
                forceOnce = false;
            }
        }

    }

    public void GameSession()
    {
        // Determine who goes first
        int player1 = 1;
        int player2 = 2;
        var currentPlayer = username1;

        int playerPick = rand.Next(player1, 3);
        Debug.Log(playerPick);

        if(playerPick == player1)
        {
            currentPlayer = username1;
            Debug.Log("Player 1 begins first.");
        }
        else if (playerPick == player2)
        {
            currentPlayer = username2;
            Debug.Log("Player 2 begins first.");
        }

        if (difficulty == 0)
        {
            for (int i = 0; i > easyRunes.Count; i++)
            {
                allRunes[i] = easyRunes[i];
            }
        }
        else if (difficulty == 1)
        {
            for (int i = 0; i > runes.Count; i++)
            {
                allRunes[i] = runes[i];
            }
        }

        // With whoever goes first, allow the player to click the rune, depending on how much they want to click in one row


        // When the player is done with their choice, move the turn over to the next player


        // When there is only one rune left, move the seesion over to gameover


    }

    public void SetUserName1(string val)
    {
        username1 = val;
    }

    public void SetUserName2(string val)
    {
        username2 = val;
    }

    public void RuneClicked(int runeIndex, int row)
    {
        Debug.Log("CLICKED");
        
        if(row == selectedRow)
        {
            //Disable all runes after the indexed rune
            for (int i = runeIndex; i < allRunes.Count; i++)
            {
                allRunes[i].SetActive(false);
            }
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
    GAMEOVER,
    MENU,
    EXITGAME
}