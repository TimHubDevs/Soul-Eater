using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class SpawnEnemy : MonoBehaviour
{
    public GameObject[] Enemy;
    private int maxEnemies = 30;
    private int currentEnemies = 0;
    private bool spawning = false; 
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && currentEnemies < maxEnemies && !spawning)
        {
            spawning = true; 
            StartCoroutine(SpawnEnemiesCoroutine());
        }
    }

    IEnumerator SpawnEnemiesCoroutine()
    {
        for (int i = 0; i < maxEnemies; i++)
        {
            int randomIndex = Random.Range(0, Enemy.Length);
            GameObject selectedObject = Enemy[randomIndex];

            float randX = Random.Range(-3.5f, 5f);
            float randZ = Random.Range(-5.3f, 4.1f);
            Vector3 Rposition = new Vector3(randX, 0, randZ);

            Instantiate(selectedObject, Rposition, selectedObject.transform.rotation);
            currentEnemies++;
            yield return new WaitForSeconds(0.1f);
        }

        spawning = false; 
    }
}

