using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpDownObstacleFollow : MonoBehaviour
{
    [SerializeField] GameObject player;
    void Update()
    {
        transform.position = new Vector2(player.transform.position.x, 0);
    }
}
