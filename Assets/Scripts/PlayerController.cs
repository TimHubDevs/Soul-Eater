using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public float speed = 7f;
    public int souls;
    public TextMeshProUGUI SoulsText;

    private void Start()
    {
        if (PlayerPrefs.HasKey("Souls"))
        {
            souls = PlayerPrefs.GetInt("Souls");
            SoulsText.text = souls.ToString();
        }
    }
    private void Update()
    {
        GetInput();
    }

    private void GetInput()
    {
        if(Input.GetKey(KeyCode.W)) 
        {
            transform.localPosition += transform.forward * speed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.S))
        {
            transform.localPosition += -transform.forward * speed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.localPosition += -transform.right * speed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.localPosition += transform.right * speed * Time.deltaTime;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Soul") 
        {
            souls++;
            other.gameObject.SetActive(false);
            SoulsText.text = souls.ToString();
            PlayerPrefs.SetInt("Souls", souls);
        }
    }
}
