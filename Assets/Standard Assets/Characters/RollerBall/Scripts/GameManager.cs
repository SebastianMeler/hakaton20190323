using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject explosion;
    public GameData gameData;
    public float currentTime;
    public Text timeText;
    public Text pointsText;
    public Text endGame;
    public bool isEnding;

    public void CheckpointCollected(Vector3 fireSpot, int pointsCheckpoint) {
        Instantiate(explosion, fireSpot, Quaternion.identity);
        AddPoints(pointsCheckpoint);
    }

    private void Start()
    {
        currentTime = gameData.timer;
        pointsText.text = "0";
    }
    private void Update()
    { 
        currentTime -= Time.deltaTime;
        timeText.text = currentTime.ToString("0.0");
        if (currentTime <= 0) {
            currentTime = 0.0f;
            GameOver(false);

        }
        int checkpointsCount = GameObject.FindGameObjectsWithTag("Checkpoint").Length;

        if (checkpointsCount<=0)
        {
            GameOver(true);
        }

        if (isEnding)
        {
            if (Input.anyKeyDown)
            {
                Time.timeScale = 1;
                SceneManager.LoadScene("RollerBall");
            }
        }

    }

    public void AddPoints(int pointsCheckpoint)
    {
        gameData.currentPoints += pointsCheckpoint;
        pointsText.text = gameData.currentPoints.ToString("0");

    }

    public void AddTime(float time)
    {
        currentTime += time;
    }

    void GameOver(bool condition) {
        Time.timeScale = 0;
        isEnding = true;
        if (!condition)
        {
            endGame.text = "Game Over \n press any key";
        }
        else
        {
            endGame.text = "U R wienner \n press any key";
        }
        
    }
}
