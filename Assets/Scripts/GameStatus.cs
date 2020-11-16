using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class GameStatus : MonoBehaviour
{

    [SerializeField]
    private TextMeshProUGUI scoreText;
    [Range(0.1f, 10f)] [SerializeField] 
    float gameSpeed = 1f;

    int currentScore;
    int pointsPerBlockDestroyed = 20;

    private void Awake()
    {
        int gameStatuscount = FindObjectsOfType<GameStatus>().Length;
        if(gameStatuscount > 1)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }
    // Update is called once per frame
    void Update()
    {
        HandleInput();
        SetScoretoUI();
    }

    private void SetScoretoUI()
    {
        if (Convert.ToInt32(scoreText.text) != currentScore)
        {
            scoreText.SetText(currentScore.ToString());
        }
    }
    public void AddToScore()
    {
        currentScore += pointsPerBlockDestroyed;
    }
    void HandleInput()
    {
        if (Input.GetKeyDown(KeyCode.KeypadPlus))
        {
            SetGameSpeed(true);
        }
        if (Input.GetKeyDown(KeyCode.KeypadMinus))
        {
            SetGameSpeed(false);
        }
    }

    private void SetGameSpeed(bool isIncrease)
    {
        int sign = isIncrease ? 1 : -1;
        if (gameSpeed <= 1)
        {
            gameSpeed += 0.1f * sign;
        }
        else
        {
            gameSpeed += 0.3f * sign;
        }
        Time.timeScale = gameSpeed;
    }
}
