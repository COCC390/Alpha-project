using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject pauseButton;
    public GameObject endGameMenu;
    public Text endGameScore;

    private GameObject gameController;
    private GameObject wraith;
    private bool isPaused;
    void Start()
    {
        wraith = GameObject.FindGameObjectWithTag("Player");
        gameController = GameObject.FindGameObjectWithTag("GameController");
        isPaused = false;
    }

    void Update()
    {
        if (isPaused)
            Time.timeScale = 0;
        else if(!isPaused && wraith.GetComponent<WraithHealth>().health > 0)
            Time.timeScale = 1;

        if (gameController.GetComponent<GameController>().isEndGame)
            EndGame();
    }

    public void PauseGame()
    {
        isPaused = true;
        pauseMenu.SetActive(true);
        pauseButton.SetActive(false);
    }

    public void ResumeGame()
    {
        isPaused = false;
        pauseMenu.SetActive(false);
        pauseButton.SetActive(true);
    }

    public void EndGame()
    {
        endGameMenu.SetActive(true);
        endGameScore.text = gameController.GetComponent<GameController>().score.ToString();
    }

    public void ReloadGame()
    {
        SceneManager.LoadScene("SampleScene", LoadSceneMode.Single);
        endGameMenu.SetActive(false);
    }

    public void ExitToMenu()
    {
        SceneManager.LoadScene("Menu", LoadSceneMode.Single);
    }
}
