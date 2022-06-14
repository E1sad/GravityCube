using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : MonoBehaviour
{
    [SerializeField] private PlayerController pc;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {   
            pc.SetGravitySpeed(0);
            pc.SetMovementSpeed(0);
            Debug.Log("!!!!");
        }
    }
}
