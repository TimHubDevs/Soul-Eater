using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform player;
    private Vector3 offset = new Vector3(0, 2.5f, -2);

    private void Update()
    {
        transform.position = player.position + offset;
    }
}
