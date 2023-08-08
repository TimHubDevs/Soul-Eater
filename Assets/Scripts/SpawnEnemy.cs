using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class SpawnEnemy : MonoBehaviour
{
    public GameObject[] Enemy;
    private int maxEnemies = 30;
    private int currentEnemies = 0;
    // Start is called before the first frame update
    void Start()
    {
        

    }

    // Update is called once per frame
    void Update()
    {
        if (currentEnemies < maxEnemies)
        {
            int randomIndex = Random.Range(0, Enemy.Length);
            GameObject selectedObject = Enemy[randomIndex];

            float randX = Random.Range(-3.5f, 5f);
            float randZ = Random.Range(-5.3f, 4.1f);
            Vector3 Rposition = new Vector3(randX, 0, randZ);

            Instantiate(selectedObject, Rposition, selectedObject.transform.rotation);
            currentEnemies++;
        }
        

    }
}


