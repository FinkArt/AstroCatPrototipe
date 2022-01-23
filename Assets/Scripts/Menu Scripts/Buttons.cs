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

    public void Exit()
    {
        Debug.Log("Мы вышли из игры");
        Application.Quit();
    }

    public void PlayAndReset()
    {
        SceneManager.LoadScene("Game");
        Time.timeScale = 1f;
    }

    public void Pause()
    {
        Time.timeScale = 0f;
        pauseMenu.SetActive(true);
    }

    public void ContinueGame()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
    }

}
