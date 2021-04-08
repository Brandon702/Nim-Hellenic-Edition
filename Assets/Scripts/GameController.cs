using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Events;

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

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //Game is running
        if (state == eState.GAME)
        {

        }
    }

    public void GameOver()
    {
        gameOverPanel.SetActive(true);
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
    EXITGAME
}