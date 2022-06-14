using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : MonoBehaviour
{
    [SerializeField] private GameObject gameobject;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            gameobject.transform.position = new Vector3(0,0,0);
            Debug.Log("!!!!");
        }
    }
}
