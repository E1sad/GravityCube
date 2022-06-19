using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Rigidbody2D playerRb;
    [SerializeField] private GameManager gameManager;
    [SerializeField] private float gravityspeed;
    [SerializeField] private float movementspeed;

    void Start()
    {
        Application.targetFrameRate = 60;
    }

    void Update()
    {
        

        if(Input.GetKeyDown(KeyCode.Space))
        {
            //playerRb.gravityScale = -1*playerRb.gravityScale;
            gravityspeed = -1 * gravityspeed;
        }
        playerRb.velocity = (transform.right * movementspeed + transform.up*gravityspeed) * Time.fixedDeltaTime;
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        gameManager.GameOver();
    }


}
