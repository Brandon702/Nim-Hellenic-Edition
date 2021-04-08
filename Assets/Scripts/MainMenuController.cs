using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuController : MonoBehaviour
{
    public GameObject OptionsPanel, CreditsPanel, InstructionsPanel, GameOverPanel, MainMenuPanel, PausePanel;

    public void StartGame()
    {
        gameObject.SetActive(true);
        MainMenuPanel.SetActive(false);
        GameOverPanel.SetActive(false);
        GameController.Instance.state = eState.GAME;
        
    }

    public void Options()
    {
        gameObject.SetActive(false);
        OptionsPanel.SetActive(true);
        MainMenuPanel.SetActive(false);
        PausePanel.SetActive(false);
    }

    public void Credits()
    {
        gameObject.SetActive(false);
        MainMenuPanel.SetActive(false);
        CreditsPanel.SetActive(true);
    }

    public void BackToMenu()
    {
        gameObject.SetActive(false);
        MainMenuPanel.SetActive(true);
        OptionsPanel.SetActive(false);
        CreditsPanel.SetActive(false);
        InstructionsPanel.SetActive(false);
        GameOverPanel.SetActive(false);
    }

    public void BackToPause()
    {
        gameObject.SetActive(true);
        PausePanel.SetActive(true);
        OptionsPanel.SetActive(false);
        CreditsPanel.SetActive(false);
        InstructionsPanel.SetActive(false);
        GameOverPanel.SetActive(false);
    }

    public void GameOver()
    {
        gameObject.SetActive(false);
        GameOverPanel.SetActive(true);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
