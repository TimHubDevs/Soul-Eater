using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    //public GameObject Camera1;
    //public GameObject Camera2;
    public float sensivity = 8f;
    public Transform Player;
    private float rotationX = 0f;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        float mouseY = Input.GetAxis("Mouse Y") * sensivity * Time.deltaTime;
        float mouseX = Input.GetAxis("Mouse X") * sensivity * Time.deltaTime;

        rotationX -= mouseY;
        rotationX = Mathf.Clamp(rotationX, -90f, 90f);

        transform.localRotation = Quaternion.Euler(rotationX,0f,0f);
        Player.Rotate(Vector3.up * mouseX);


        //if (Input.GetKeyDown("v"))
        //{
        //Camera1.SetActive(!Camera1.activeInHierarchy);
        //Camera2.SetActive(!Camera2.activeInHierarchy);
        //}
    }
}
