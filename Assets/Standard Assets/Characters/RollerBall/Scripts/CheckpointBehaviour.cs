using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointBehaviour : MonoBehaviour
{
    public GameManager gameManager;
    public int points;
    public float checkpointTime;
   

    private void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            gameManager.CheckpointCollected(gameObject.transform.position, points);
            gameManager.AddTime(checkpointTime);
            Destroy(gameObject);
        }
    }


    void AddTime()
    {
        gameManager.currentTime += 5.0f;
    }
}
