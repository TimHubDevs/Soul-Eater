using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PoolObject : MonoBehaviour
{
    public static PoolObject SharedInstance;
    public List <GameObject> PoolObjects;
    private GameObject selectedObject;
    public int amounttopull;
    // Start is called before the first frame update
   private void Awake()
    {
        SharedInstance = this;
    }

    // Update is called once per frame
    private void Start()
    {
       var PoolObject=new List<GameObject>();
        GameObject twp;
        for(int i=0;i<amounttopull;i++)
        {
            twp=Instantiate(selectedObject,transform.position, selectedObject.transform.rotation);
            twp.SetActive(false);
            PoolObjects.Add(twp);
        }
    }
}
