using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    [Header("Ball Setting")]
    public Ball ball;

    [Space]

    [Header("Player")]
    public Paddle playerPaddle;
    public int playerScore;
    public TextMeshProUGUI playerScoreText;

    [Space]

    [Header("Computer")]
    public Paddle computerPaddle;
    public int computerScore;
    public TextMeshProUGUI computerScoreText;

    // Start is called before the first frame update
    void Start()
    {
        NewGame();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
		{
            NewGame();
		}
    }

    public void NewGame()
	{
        SetPlayerScore(0);
        SetComputerScore(0);
        StartRound();
	}

    public void StartRound()
    {
        playerPaddle.ResetPosition();
        computerPaddle.ResetPosition();
        ball.ResetBall();
        ball.AddStartForce();
    }

    public void PlayerScores()
	{
        SetPlayerScore(playerScore++);
        StartRound();
	}

    public void ComputerScores()
    {
        SetComputerScore(computerScore++);
        StartRound();
    }

    public void SetPlayerScore(int score)
	{
        playerScore = score;
        playerScoreText.text = score.ToString();
	}

    public void SetComputerScore(int score)
    {
        computerScore = score;
        computerScoreText.text = score.ToString();
    }

}
