using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public int leftScore = 0;
    public int rightScore = 0;
    public float resetTime = 3f;

    public int scoreToWin = 11;

    public Ball ball;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI flavorText;
    private bool left;

    void Start()
    {
        UpdateScoreUI();
        Invoke(nameof(Flavor6), 0f);
    }

    void UpdateScoreUI()
    {
        scoreText.text = $"{leftScore} : {rightScore}";
        flavorText.text = "";
    }

    public void OnGoalScored()
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
            Debug.Log($"Game Over! {winner} Wins!");

            Debug.Log("Score reset. Left: 0 Right: 0");
            flavorText.text = "GOOOOOOOOOOOAAAAAAAAL";
            Invoke(nameof(Flavor2), resetTime);
        } else {
            flavorText.text = "GOOOOOOOOOOOAAAAAAAAL";
            Invoke(nameof(Flavor), resetTime);
        }
    }

    void Flavor() {
        string scorer = left ? "Right" : "Left";
        flavorText.text = $"Point {scorer}";
        Invoke(nameof(ResetBall), resetTime);
    }

    void Flavor2() {
        string scorer = left ? "Right" : "Left";
        flavorText.text = $"{scorer} Wins!";
        Invoke(nameof(Flavor3), resetTime);
    }

    void Flavor3() {
        flavorText.text = $"Resetting Score...";
        leftScore = 0;
        rightScore = 0;
        Invoke(nameof(Flavor4), 1f);
    }

    void Flavor4() {
        flavorText.text = $"Painting Balls...";
        Invoke(nameof(Flavor5), 0.8f);
    }

    void Flavor5() {
        flavorText.text = $"Crafting Powerups...";
        Invoke(nameof(Flavor6), 0.6f);
    }

    void Flavor6() {
        flavorText.text = $"Go Time";
        Invoke(nameof(ResetBall), resetTime);
    }

    void ResetBall() {
        flavorText.text = "";
        ball.Reset(left);
    }
}
