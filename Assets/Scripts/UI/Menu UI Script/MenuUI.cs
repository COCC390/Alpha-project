using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuUI : MonoBehaviour
{
    public GameObject credit;
    public void StartGame()
    {
        SceneManager.LoadScene("SampleScene", LoadSceneMode.Single);
    }

    public void HighScore()
    {

    }

    public void Credit()
    {
        credit.SetActive(true);
    }

    public void ReturnButtonClick()
    {
        credit.SetActive(false);
    }    

    public void ExitGame()
    {
        Application.Quit();
    }
}
