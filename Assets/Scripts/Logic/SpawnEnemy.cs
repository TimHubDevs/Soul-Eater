using System.Collections.Generic;
using UnityEngine;

namespace SoulEater.Logic
{
    public class SpawnEnemy : MonoBehaviour
    {
        [SerializeField] private GameObject[] _enemies;
        [SerializeField] private Transform parentLumberjacksTransform;
        [SerializeField] private float xRangeSpawn;
        [SerializeField] private float zRangeSpawn;

        private List<GameObject> _pooledEnemies;
        private int maxEnemies = 30;

        private void Start()
        {
            _pooledEnemies = new List<GameObject>();
            for (int i = 0; i < maxEnemies; i++)
            {
                int randomIndex = Random.Range(0, _enemies.Length);
                GameObject randomEnemy = _enemies[randomIndex];

                GameObject enemy = Instantiate(randomEnemy, Vector3.zero, Quaternion.identity, parentLumberjacksTransform);
                enemy.SetActive(false);
                _pooledEnemies.Add(enemy);
            }

            SpawnEnemies();
        }

        private void SpawnEnemies()
        {
            for (int i = 0; i < maxEnemies; i++)
            {
                GameObject enemy = GetPooledEnemy();

                if (enemy != null)
                {
                    float randX = Random.Range(-xRangeSpawn, xRangeSpawn);
                    float randZ = Random.Range(-zRangeSpawn, zRangeSpawn);
                    Vector3 randomPosition = new Vector3(randX, 0, randZ);
                    enemy.transform.position = randomPosition;
                    enemy.SetActive(true);
                }
            }
        }

        private GameObject GetPooledEnemy()
        {
            foreach (GameObject enemy in _pooledEnemies)
            {
                if (!enemy.activeInHierarchy)
                {
                    return enemy;
                }
            }

            return null;
        }

        public List<GameObject> GetEnemies()
        {
            return _pooledEnemies;
        }
    }
}