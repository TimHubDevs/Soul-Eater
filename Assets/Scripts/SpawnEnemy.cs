using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    public List<GameObject> pooledEnemies;
    public GameObject[] Enemy;
    private int maxEnemies = 30;
    private int currentEnemies = 0;
    public Transform parentLumberjacks;

    void Start()
    {
        pooledEnemies = new List<GameObject>();
        for (int i = 0; i < maxEnemies; i++)
        {
            int randomIndex = Random.Range(0, Enemy.Length);
            GameObject selectedObject = Enemy[randomIndex];

            GameObject enemy = Instantiate(selectedObject, Vector3.zero, Quaternion.identity, parentLumberjacks);
            enemy.SetActive(false);
            pooledEnemies.Add(enemy); 
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && currentEnemies < maxEnemies)
        {
            for (int i = 0; i < maxEnemies; i++)
            {
                GameObject enemy = GetPooledEnemy(); 

                if (enemy != null)
                {
                    float randX = Random.Range(-3.5f, 5f);
                    float randZ = Random.Range(-5.3f, 4.1f);
                    Vector3 Rposition = new Vector3(randX, 0, randZ);

                    enemy.transform.position = Rposition;
                    enemy.SetActive(true);
                    currentEnemies++;
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            DeactivateAllEnemies();
        }
    }

    GameObject GetPooledEnemy()
    {
        foreach (GameObject enemy in pooledEnemies)
        {
            if (!enemy.activeInHierarchy)
            {
                return enemy;
            }
        }
        return null;
    }

    void DeactivateAllEnemies()
    {
        foreach (GameObject enemy in pooledEnemies)
        {
            enemy.SetActive(false); 
        }
        currentEnemies = 0; 
    }
}
