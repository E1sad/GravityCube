using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    [SerializeField] GameObject menuCanvas, gameOverCanvas, gamePlayCanvas;
    [SerializeField] Rigidbody2D playerRb;
    //[SerializeField] private float gravityspeed;
    //[SerializeField] private float movementspeed;

    void Start()
    {
        Menu();
        Time.timeScale = 1;
    }

    void FixedUpdate()
    {
        CheckIfGameStart();
    }
    
    void CheckIfGameStart()
    {
        if(Input.GetKeyDown(KeyCode.Space) && playerRb.bodyType == RigidbodyType2D.Static)
        {
            playerRb.bodyType = RigidbodyType2D.Dynamic;

        }
    }

    public void GamePlay()
    { 
        menuCanvas.SetActive(false);
        gameOverCanvas.SetActive(false);
        gamePlayCanvas.SetActive(true);
    }

    public void GameOver()
    {
        menuCanvas.SetActive(false);
        gameOverCanvas.SetActive(true);
        gamePlayCanvas.SetActive(false);
        playerRb.bodyType = RigidbodyType2D.Static;
    }

    public void Menu()
    {
        playerRb.bodyType = RigidbodyType2D.Static;
        menuCanvas.SetActive(true);
        gameOverCanvas.SetActive(false);
        gamePlayCanvas.SetActive(false);
    }


}
