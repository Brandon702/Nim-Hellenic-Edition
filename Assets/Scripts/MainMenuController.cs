using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuController : MonoBehaviour
{
    public GameObject optionPanel, creditsPanel, VictoryPanel;

    public void StartGame()
    {
        gameObject.SetActive(false);
        GameController.Instance.state = eState.GAME;
    }

    public void Options()
    {
        gameObject.SetActive(false);
        optionPanel.SetActive(true);
    }

    public void Credits()
    {
        gameObject.SetActive(false);
        creditsPanel.SetActive(true);
    }

    public void BackToMenu()
    {
        gameObject.SetActive(true);
        optionPanel.SetActive(false);
        creditsPanel.SetActive(false);
        VictoryPanel.SetActive(false);
    }

    public void Victory()
    {
        gameObject.SetActive(false);
        VictoryPanel.SetActive(true);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

}
