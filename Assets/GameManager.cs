using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int leftScore = 0;
    public int rightScore = 0;

    public int scoreToWin = 11;

    public Ball ball;

    void Start()
    {
        ball.Reset(true);
    }

    public void OnGoalScored(bool left)
    {

        if (left) {
            rightScore++;
        }
        else {
            leftScore++;
        }

        string scorer = left ? "Right" : "Left";
        Debug.Log($"{scorer} scores! Left: {leftScore} Right: {rightScore}");

        if (leftScore >= scoreToWin || rightScore >= scoreToWin)
        {
            string winner = leftScore >= scoreToWin ? "Left" : "Right";
            Debug.Log($"Game Over! {winner} Paddle Wins!");

            leftScore = 0;
            rightScore = 0;

            Debug.Log("Score reset. Left: 0 Right: 0");
        }

        ball.Reset(left);
    }
}
