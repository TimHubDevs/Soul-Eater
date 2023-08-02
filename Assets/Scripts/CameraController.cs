using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    float rotationX = 0f;
    float rotationY = 0f;

    public GameObject Camera1;
    public GameObject Camera2;


    public float sensivity = 8f;

    private void Update()
    {
        rotationY += Input.GetAxis("Mouse X") * sensivity;
        rotationX += Input.GetAxis("Mouse Y") * sensivity * -1;
        transform.localEulerAngles = new Vector3(rotationX, rotationY, 0);

        if (Input.GetKeyDown("v"))
        {
            Camera1.SetActive(!Camera1.activeInHierarchy);
            Camera2.SetActive(!Camera2.activeInHierarchy);
        }
    }
}
