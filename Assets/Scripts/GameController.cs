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
    [Range(0,1)]public int difficulty = 0;
    public List<GameObject> runes = new List<GameObject>();
    public List<GameObject> easyRunes = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        foreach (var obj in runes)
            obj.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //Game is running
        if (state == eState.GAME)
        {
            //Check if list[1] obj is enabled for game over
           /* if (gameObject.GetComponent<Button>().interactable == false)
            {
                GameController.Instance.state = eState.GAMEOVER;
            }*/
        }

        if (state == eState.STARTGAME)
        {
            //Set runes active
            //Easy goes up to index [8]
            if(difficulty == 0)
            {
                foreach (var obj in easyRunes)
                    obj.SetActive(true);
            }
            else
            {
                foreach (var obj in easyRunes)
                    obj.SetActive(true);
            }
        }
    }

    public void GameOver()
    {
        gameOverPanel.SetActive(true);
        foreach (var obj in runes)
            obj.SetActive(false);
    }
}

public enum eState
{
    TITLE,
    STARTGAME,
    GAME,
    PAUSE,
    OPTIONS,
    INSTRUCTIONS,
    GAMEOVER,
    CREDITS,
    MENU,
    EXITGAME
}