using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject explosion;

    public void CheckpointCollected(Vector3 fireSpot, int pointsCheckpoint) {
        Instantiate(explosion, fireSpot, Quaternion.identity);
    }

}
