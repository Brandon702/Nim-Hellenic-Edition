using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuController : MonoBehaviour
{
    public GameObject OptionsPanel, CreditsPanel, InstructionsPanel, GameOverPanel, MainMenuPanel, PausePanel, GameSettingsPanel1, GameSettingsPanel2;

    public void StartGame()
    {
        gameObject.SetActive(true);
        MainMenuPanel.SetActive(false);
        PausePanel.SetActive(false);
        GameSettingsPanel1.SetActive(false);
        GameSettingsPanel2.SetActive(false);
        GameController.Instance.state = eState.GAME;
        Console.WriteLine("Start Game menu controller");
    }

    public void StartGameSettings1()
    {
        //Names
        //gameObject.SetActive(false);
        MainMenuPanel.SetActive(false);
        GameOverPanel.SetActive(false);
        GameSettingsPanel1.SetActive(true);
        GameController.Instance.state = eState.MENU;
        Console.WriteLine("Settings1 menu controller");
    }

    public void StartGameSettings2()
    {
        //Difficulty
        //gameObject.SetActive(false);
        GameOverPanel.SetActive(false);
        GameSettingsPanel1.SetActive(false);
        GameSettingsPanel2.SetActive(true);
        Console.WriteLine("Settings2 menu controller");
    }

    public void Options()
    {
        gameObject.SetActive(false);
        OptionsPanel.SetActive(true);
        MainMenuPanel.SetActive(false);
        PausePanel.SetActive(false);
        Console.WriteLine("Options menu controller");
    }

    public void Instructions()
    {
        gameObject.SetActive(false);
        InstructionsPanel.SetActive(true);
        MainMenuPanel.SetActive(false);
        PausePanel.SetActive(false);
        Console.WriteLine("Instructions menu controller");
    }

    public void Credits()
    {
        gameObject.SetActive(false);
        MainMenuPanel.SetActive(false);
        CreditsPanel.SetActive(true);
        Console.WriteLine("Credits menu controller");
    }

    public void Back()
    {
        if (GameController.Instance.state == eState.PAUSE)
        {
            BackToPause();
        }
        else
        {
            BackToMenu();
        }
    }

    public void Pause()
    {
        if (GameController.Instance.state == eState.GAME)
        {
            PausePanel.SetActive(true);
            MainMenuPanel.SetActive(false);
            OptionsPanel.SetActive(false);
            CreditsPanel.SetActive(false);
            InstructionsPanel.SetActive(false);
            GameOverPanel.SetActive(false);
            GameController.Instance.state = eState.PAUSE;
        }
    }

    //Back to main menu
    public void BackToMenu()
    {
        //gameObject.SetActive(false);
        MainMenuPanel.SetActive(true);
        PausePanel.SetActive(false);
        OptionsPanel.SetActive(false);
        CreditsPanel.SetActive(false);
        InstructionsPanel.SetActive(false);
        GameOverPanel.SetActive(false);
        GameController.Instance.state = eState.TITLE;
        Console.WriteLine("BacktoMenu menu controller");
    }

    //Back to pause menu
    public void BackToPause()
    {
        gameObject.SetActive(false);
        PausePanel.SetActive(true);
        MainMenuPanel.SetActive(false);
        OptionsPanel.SetActive(false);
        CreditsPanel.SetActive(false);
        InstructionsPanel.SetActive(false);
        GameOverPanel.SetActive(false);
        GameController.Instance.state = eState.PAUSE;
        Console.WriteLine("BacktoPause menu controller");
    }

    public void GameOver()
    {
        gameObject.SetActive(false);
        GameOverPanel.SetActive(true);
        GameController.Instance.state = eState.GAMEOVER;
        Console.WriteLine("Gameover menu controller");
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
