using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    public bool left = true;
    public GameManager gameManager;

    void OnTriggerEnter(Collider other)
    {
        Ball ball = other.GetComponent<Ball>();
        if (ball == null) return;

        gameManager.OnGoalScored(left);
    }
}
