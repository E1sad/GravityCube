using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Rigidbody2D playerRb;
    [SerializeField] private float movementspeed;

    void Update()
    {
        playerRb.velocity = transform.right*movementspeed*Time.fixedDeltaTime;

        if(Input.GetKeyDown(KeyCode.Space))
        {
            playerRb.gravityScale = -1*playerRb.gravityScale;
        }
    }
}
