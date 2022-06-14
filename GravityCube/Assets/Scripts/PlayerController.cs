using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Rigidbody2D playerRb;
    [SerializeField] readonly float movementspeed;
    [SerializeField] readonly float gravityspeed;
    

    void Start()
    {
        Invoke("NewGravity", 0.7f);
    }
    void Update()
    {
        playerRb.velocity = transform.right*movementspeed*Time.fixedDeltaTime;

        if(Input.GetKeyDown(KeyCode.Space))
        {
            playerRb.gravityScale = -1*playerRb.gravityScale;
        }
    }

    void NewGravity()
    {
        playerRb.gravityScale = gravityspeed;
    }
}
