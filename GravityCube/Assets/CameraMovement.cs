using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement1 : MonoBehaviour
{
    void Update()
    {
        transform.position = new Vector3(transform.position.x, 0, transform.position.z);
    }
}
