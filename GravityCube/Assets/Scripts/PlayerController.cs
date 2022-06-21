using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Rigidbody2D playerRb;
    [SerializeField] private GameManager gameManager;
    [SerializeField] private float gravityspeed;
    [SerializeField] private float movementspeed;
    private int score = 0;

    public int GetScore()
    {
        return score;
    }
    public void SetScore(int newscore)
    {
        score = newscore;
    }

    void Start()
    {
        Application.targetFrameRate = 60;
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            gravityspeed = -1 * gravityspeed;
        }
        if(playerRb.bodyType == RigidbodyType2D.Dynamic)
        playerRb.velocity = (transform.right * movementspeed + transform.up*gravityspeed) * Time.fixedDeltaTime;
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        gameManager.GameOver();
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        score += 1;
    }

}
