using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuController : MonoBehaviour
{
    public GameObject OptionsPanel, CreditsPanel, InstructionsPanel, GameOverPanel, MainMenuPanel, PausePanel, GameSettingsPanel1, GameSettingsPanel2, PauseOptionsPanel, PauseInstructionsPanel;

    public void StartGame()
    {
        gameObject.SetActive(true);
        MainMenuPanel.SetActive(false);
        PausePanel.SetActive(false);
        GameSettingsPanel1.SetActive(false);
        GameSettingsPanel2.SetActive(false);
        GameController.Instance.state = eState.GAME;
    }

    public void StartGameSettings1()
    {
        //Names
        gameObject.SetActive(false);
        MainMenuPanel.SetActive(false);
        GameOverPanel.SetActive(false);
        GameSettingsPanel1.SetActive(true);
        GameController.Instance.state = eState.MENU;
    }

    public void StartGameSettings2()
    {
        //Difficulty
        gameObject.SetActive(false);
        GameOverPanel.SetActive(false);
        GameSettingsPanel1.SetActive(false);
        GameSettingsPanel2.SetActive(true);
        GameController.Instance.state = eState.STARTGAME;
    }

    public void Options()
    {
        gameObject.SetActive(false);
        OptionsPanel.SetActive(true);
        MainMenuPanel.SetActive(false);
        PausePanel.SetActive(false);
        GameController.Instance.state = eState.OPTIONS;
    }

    public void PauseOptions()
    {
        gameObject.SetActive(false);
        PauseOptionsPanel.SetActive(true);
        MainMenuPanel.SetActive(false);
        PausePanel.SetActive(false);
        GameController.Instance.state = eState.OPTIONS;
    }

    public void Instructions()
    {
        gameObject.SetActive(false);
        InstructionsPanel.SetActive(true);
        MainMenuPanel.SetActive(false);
        PausePanel.SetActive(false);
        GameController.Instance.state = eState.INSTRUCTIONS;
    }

    public void PauseInstructions()
    {
        gameObject.SetActive(false);
        PauseInstructionsPanel.SetActive(true);
        MainMenuPanel.SetActive(false);
        PausePanel.SetActive(false);
        GameController.Instance.state = eState.INSTRUCTIONS;
    }

    public void Credits()
    {
        gameObject.SetActive(false);
        MainMenuPanel.SetActive(false);
        CreditsPanel.SetActive(true);
        GameController.Instance.state = eState.CREDITS;
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
        PauseOptionsPanel.SetActive(false);
        PauseInstructionsPanel.SetActive(false);
        GameController.Instance.state = eState.PAUSE;
    }

    public void GameOver()
    {
        gameObject.SetActive(false);
        GameOverPanel.SetActive(true);
        GameController.Instance.state = eState.GAMEOVER;
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
