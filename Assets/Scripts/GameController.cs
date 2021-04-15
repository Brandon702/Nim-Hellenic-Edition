using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Events;
using System;
using System.Linq;
using UnityEngine.SceneManagement;

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
    public GameObject turnDisplay;
    //public GameObject winnerDisplay;
    public System.Random rand = new System.Random();
    public bool forceOnce = true;

    string currentPlayer;
    public TextMeshProUGUI playerTurn;
    public TextMeshProUGUI winner;
    int runeRow;
    int selectedRow=99999;
    public InputSystem input;

    // Start is called before the first frame update
    void Start()
    {
        DifficultyChanged();
        foreach (var obj in runes)
            obj.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (state == eState.MENU)
        {
            turnDisplay.SetActive(false);
            foreach (var obj in runes)
                obj.SetActive(false);
            forceOnce = true;
        }

        //Game is running
        if (state == eState.GAME)
        {
            //If on menu state deactivate
            

            if (forceOnce == true)
            {
                
                if (difficulty == 0)
                {
                    foreach (var obj in easyRunes)
                        obj.SetActive(true);
                    //Debug.Log("Easy selected");
                }
                else
                {
                    foreach (var obj in runes)
                        obj.SetActive(true);
                    //Debug.Log("Hard selected");
                }
                GameSession();
                
                forceOnce = false;
            }
        }

    }

    public void GameSession()
    {
        for (int i = 0; i < runes.Count; i++)
        {
            runes[i].GetComponent<Button>().interactable = true;
            Debug.Log("Loop Ran");
        }
        // Determine who goes first
        int player1 = 1;
        int player2 = 2;
        currentPlayer = username1;

        int playerPick = rand.Next(player1, 3);
        Debug.Log(playerPick);

        if(playerPick == player1)
        {
            currentPlayer = username1;
            playerTurn.text = username1;
            Debug.Log("Player 1 begins first.");
        }
        else if (playerPick == player2)
        {
            currentPlayer = username2;
            playerTurn.text = username2;
            Debug.Log("Player 2 begins first.");
        }
        turnDisplay.SetActive(true);
        if (difficulty == 0)
        {
            selectedRow = 2;
            Debug.Log("SelectedRow: " + selectedRow);
        }
        else if (difficulty == 1)
        {
            selectedRow = 3;
            Debug.Log("SelectedRow: " + selectedRow);
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


    public void setRow(int row)
    {
        runeRow = row;
    }

    public void ChangePlayer()
    {

        if(currentPlayer == username1)
        {
            currentPlayer = username2;
            playerTurn.text = username2;
        }
        else if (currentPlayer == username2)
        {
            currentPlayer = username1;
            playerTurn.text = username1;
        }
    }

    public void RuneClicked(int runeIndex)
    {
        //if player = non computer run normally, otherwise do a random selection between 1-3 (safety might be needed)
        if(runeRow == selectedRow)
        {
            Debug.Log("Rune Index: " + runeIndex);
            Debug.Log("Rune Row: " + runeRow);
            if (runeIndex == 0)
            {
                GameOver();
            }
            //Disable all runes after the indexed rune
            Debug.Log("Before For loop");
            for (int i = runeIndex; i < runes.Count; i++)
            {
                //runes[i].SetActive(false);
                runes[i].GetComponent<Button>().interactable = false;
                Debug.Log("Loop Ran");
            }

            if (runeIndex == 9)
            {
                //Set to row 3
                selectedRow = 2;
                Debug.Log("Setting rune row to 3");
            }
            if (runeIndex == 4)
            {
                //Set to row 2
                selectedRow = 1;
                Debug.Log("Setting rune row to 2");
            }
            if (runeIndex == 1)
            {
                //Set to row 1
                selectedRow = 0;
                Debug.Log("Setting rune row to 1");
            }
            ChangePlayer();
        }
    }

    public void GameOver()
    {
        if (currentPlayer == username1)
        {
            winner.text = username2 + " has won!";
        }
        else if (currentPlayer == username2)
        {
            winner.text = username1 + " has won!";
        }

        gameOverPanel.SetActive(true);
        foreach (var obj in runes)
            obj.SetActive(true);
        for (int i = 0; i < runes.Count; i++)
        {
            runes[i].GetComponent<Button>().interactable = true;
        }
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