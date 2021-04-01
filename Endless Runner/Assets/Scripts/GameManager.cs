using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    int score;
    public static GameManager inst;

    public Text scoreText;
    public RobotMovement robotMovement;
    public Button startButton;

    public void IncrementScore()
    {
        score++;
        scoreText.text = "SCORE: " + score;

        //icrease player speed
        robotMovement.speed += robotMovement.speedIncreasePerPoint;
    }


    private void Awake()
    {
        inst = this;
        Time.timeScale = 0f;
    }

    private void OnEnable()
    {
        startButton.onClick.AddListener(StartGame);
    }

    private void OnDisable()
    {
        startButton.onClick.RemoveListener(StartGame);
    }

    
    private void StartGame()
    {
        Time.timeScale = 1f;

        startButton.gameObject.SetActive(false);
    }
}
