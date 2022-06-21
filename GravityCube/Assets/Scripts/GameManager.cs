using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private string bestScoreKey;
    [SerializeField] GameObject menuCanvas, gameOverCanvas, gamePlayCanvas, textStart, player;
    [SerializeField] Rigidbody2D playerRb;
    [SerializeField] PlayerController playerScript;
    [SerializeField] TextMeshProUGUI ScoreText, gameOverScore, gameOverBestScore;
    private int newScore;

    void Start()
    {
        Menu();
        Time.timeScale = 1;
    }

    void FixedUpdate()
    {
        CheckIfGameStart();
        Score();
    }
    
    void CheckIfGameStart()
    {
        if(Input.GetKeyDown(KeyCode.Space) && playerRb.bodyType == RigidbodyType2D.Static)
        {
            playerRb.bodyType = RigidbodyType2D.Dynamic;
            textStart.SetActive(false);
        }
    }

    public void GamePlay()
    {
        player.transform.position = new Vector2(0, 0);
        menuCanvas.SetActive(false);
        gameOverCanvas.SetActive(false);
        gamePlayCanvas.SetActive(true);
        playerScript.SetScore(0);
    }

    public void GameOver()
    {
        menuCanvas.SetActive(false);
        gameOverCanvas.SetActive(true);
        gamePlayCanvas.SetActive(false);
        playerRb.bodyType = RigidbodyType2D.Static;
        BestScore();
    }

    public void Menu()
    {
        playerRb.bodyType = RigidbodyType2D.Static;
        menuCanvas.SetActive(true);
        gameOverCanvas.SetActive(false);
        gamePlayCanvas.SetActive(false);
    }

    void Score()
    {
        ScoreText.text = "" + playerScript.GetScore();
        newScore = playerScript.GetScore();
    }

    void BestScore()
    {
        int bestScore = PlayerPrefs.GetInt(bestScoreKey);
        if(newScore > bestScore)
        {
            bestScore = newScore;
            PlayerPrefs.SetInt(bestScoreKey, bestScore);
            gameOverScore.text = "Score: " + newScore;
            gameOverBestScore.text = "Best: " + bestScore;
        }
        else
        {
            gameOverScore.text = "Score: " + newScore;
            gameOverBestScore.text = "Best: " + bestScore;
        }
    }
}
