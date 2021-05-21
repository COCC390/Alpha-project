using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public GameObject enemy;
    public GameObject homeTrigger;
    public int spawnLimit = 5;
    public GameObject wraith;
    public Text scoreText;
    public int score;
    public bool isEndGame;

    private Vector3 spawnPosition;
    private float randomY;
    
    void Update()
    {
        randomY = Random.Range(-3.38f, 5.43f);
        spawnPosition = new Vector3(26.1f, randomY, 0);
        if (spawnLimit > 0)
        {
            SpawnRandomEnemy();
            CancelInvoke("UpdateNextAttackCycle");
        }
        else
            Invoke("UpdateNextAttackCycle", 5f);

        WraithDeadCheck();
        if (homeTrigger.GetComponent<HomeTrigger>().homeHealth == 0)
            StopGame();

        scoreText.text = score.ToString();
    }

    private void SpawnRandomEnemy()
    {
        Instantiate(enemy, spawnPosition, Quaternion.identity);
        spawnLimit -= 1;
    }

    public void UpdateNextAttackCycle()
    {
        if (spawnLimit < 1)
            spawnLimit = Random.Range(2, 5);
    }

    private void WraithDeadCheck()
    {
        int wraithHealth = wraith.GetComponent<WraithHealth>().health;
        if (wraithHealth == 0)
            Invoke("StopGame", 1f);
    }


    private void StopGame()
    {
        Time.timeScale = 0;
        isEndGame = true;
    }
}
