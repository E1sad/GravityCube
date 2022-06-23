using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private string bestScoreKey;
    [SerializeField] GameObject menuCanvas, gameOverCanvas, gamePlayCanvas, textStart, player, ObstaclePrefab;
    [SerializeField] Rigidbody2D playerRb;
    [SerializeField] PlayerController playerScript;
    [SerializeField] TextMeshProUGUI ScoreText, gameOverScore, gameOverBestScore;
    private float obstacleX = 3f, obstacleY = -0.6f, playerX;
    private int newScore,randomNum;
    

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
    void Update()
    {
        CreateRandomObstacle();
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

    //Random Obstacles
    void CreateRandomObstacle()
    {
        playerX = player.transform.position.x;
        if (playerX-obstacleX > -5)
        {
            randomNum = Random.Range(0, 2);
            if (randomNum == 0)
            {
                obstacleY = -0.6f;
                Instantiate(ObstaclePrefab, new Vector2(obstacleX, obstacleY), Quaternion.identity);
            }
            if (randomNum == 1)
            {
                obstacleY = 0.6f;
                Instantiate(ObstaclePrefab, new Vector2(obstacleX, obstacleY), Quaternion.Euler(0f,0f,180f));
            }
            obstacleX += 7;
        }
    }
}
