using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PoolObject : MonoBehaviour
{
    public Button deactivateButton;
    public static PoolObject SharedInstance;
    public List<GameObject> PoolObjects;
    private GameObject selectedObject;
    public int amounttopull;

    private void Awake()
    {
        SharedInstance = this;
    }

    private void Start()
    {
       
        PoolObjects = new List<GameObject>();
        for (int i = 0; i < amounttopull; i++)
        {
            GameObject obj = Instantiate(selectedObject, transform.position, selectedObject.transform.rotation);
            obj.SetActive(false);
            PoolObjects.Add(obj);
        }

       
        deactivateButton.onClick.AddListener(DeactivateAllObjects);
    }

    private void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Q))
        {
            DeactivateAllObjects();
        }
    }

    public void DeactivateAllObjects()
    {
        foreach (GameObject obj in PoolObjects)
        {
            obj.SetActive(false);
        }
    }
}
