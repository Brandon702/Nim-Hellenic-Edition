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

    [Header("Month/Year System")]
    [Tooltip("The name for each month, in order, go here")]
    public string[] monthNames;
    [Tooltip("Change this value to change the initial year before running")]
    public int year = 3402;
    public float monthTimer;
    public Slider sldMonth;
    public TMP_Text monthText, yearText;

    [Header("Player")]
    public Nation playerNation;
    public TMP_Text nationText, currChangeText, prestChangeText, currCurrText, currPrestText;

    [Header("Other variables")]
    public ProvinceView pv;
    public List<Province> allProvinces;
    public eState state = eState.TITLE;
    public UnityEvent nationMapMode, clearMapMode, updateCurrAndPrest;
    public TMP_Text scoreText;
    public TMP_Text nationNameDisplay;
    public GameObject victoryPanel;
    public GameObject currentSelectedProv;
    public GameObject unit;

    private float monthTimeLeft; 
    int month = 0;

    // Start is called before the first frame update
    void Start()
    {
        monthTimeLeft = monthTimer;

        GetPlayerCurrPM();
        GetPlayerPrestPM();
        nationNameDisplay.text = playerNation.nationName;
    }

    // Update is called once per frame
    void Update()
    {
        //Game is running
        if(state == eState.GAME)
        {
            monthTimeLeft -= Time.deltaTime;

            //sldMonth.value = 1 - (monthTimeLeft / monthTimer);

            GetPlayerCurrPM();
            GetPlayerPrestPM();

            if(monthTimeLeft <= 0)
            {
                month++;
                if(month >= monthNames.Length)
                {
                    month = 0;
                    year++;
                }

                updateCurrAndPrest.Invoke();
                
                currCurrText.text = playerNation.currentCurr.ToString();
                currPrestText.text = playerNation.currentPrest.ToString();

                monthTimeLeft = monthTimer;
            }

            monthText.text = monthNames[month];
            yearText.text = year + "";

            if(playerNation)
            {
                if (playerNation.controlledProvinces.Count >= Mathf.FloorToInt(allProvinces.Count / 2) || year == 3403)
                {
                    print("Player wins");
                    Victory();
                    CalculateScore();
                    state = eState.END_GAME;
                }
            }
        }
    }
    public void GetPlayerCurrPM()
    {
        currChangeText.text = ((playerNation.currChangePerMonth >= 0) ? "+" : "-") +
                    Mathf.Abs(playerNation.currChangePerMonth);

        currChangeText.color = (playerNation.currChangePerMonth >= 0) ? Color.green : Color.red;

        currCurrText.text = playerNation.currentCurr.ToString();
    }

    public void GetPlayerPrestPM()
    {
        prestChangeText.text = ((playerNation.prestChangePerMonth >= 0) ? "+" : "-") +
                    Mathf.Abs(playerNation.prestChangePerMonth);

        prestChangeText.color = (playerNation.prestChangePerMonth >= 0) ? Color.green : Color.red;

        currPrestText.text = playerNation.currentPrest.ToString();
    }

    public void InvokeNations(bool on)
    {
        if (on)
            nationMapMode.Invoke();
        else
            clearMapMode.Invoke();
    }

    public void CalculateScore()
    {
        int score;

        score = (((playerNation.controlledProvinces.Count + playerNation.fullyControlledRegions.Count)* playerNation.currentPrest)+ playerNation.currentCurr);
        scoreText.text = score.ToString();

        //return score;
    }

    public void CreateUnit()
    {
        Instantiate(unit, currentSelectedProv.transform.GetChild(0).position, Quaternion.identity);
    }

    public void Victory()
    {
        victoryPanel.SetActive(true);
    }
}

public enum eState
{
    TITLE,
    CHOOSING_NATION,
    GAME,
    PAUSE,
    END_GAME
}