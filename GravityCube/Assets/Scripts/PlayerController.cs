using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Rigidbody2D playerRb;
    [SerializeField] private float movementspeed;
    [SerializeField] private float gravityspeed;


    public void SetMovementSpeed(float newone)
    {
        movementspeed = newone;
    }    
    public void SetGravitySpeed(float newone)
    {
        playerRb.gravityScale = newone;
    } 


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
