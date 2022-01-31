using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{
    [SerializeField] public GameObject playAndResetButton;
    [SerializeField] public GameObject exitButton;
    [SerializeField] public GameObject pauseButton;
    [SerializeField] public GameObject continueButton;
    [SerializeField] public GameObject pauseMenu;
    [SerializeField] public GameObject loseMenu;
    [SerializeField] public GameObject mainMenuButton;
    [SerializeField] public GameObject scorePanel;


    private void FixedUpdate()
    {
        LoseMenu();
                
    }
    public void Exit()
    {
        Debug.Log("Мы вышли из игры");
        Application.Quit();
    }

    public void PlayAndReset()
    {
        SceneManager.LoadScene("Game");
        Time.timeScale = 1f;
        Score.score = 0;
        Score.scoreFish = 0;
    }

    public void Pause()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
    }

    public void ContinueGame()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
    }

    public void LoseMenu()
    {
        if (!FindObjectOfType<Cat>())
        {
            loseMenu.SetActive(true);
            scorePanel.SetActive(false);
            Time.timeScale = 0f;
        }
        
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("Main Menu");
        Time.timeScale = 1f;
    }


}
