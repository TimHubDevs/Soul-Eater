using UnityEngine;

namespace SoulEater.Logic
{
    public class DevConsoleWindow : MonoBehaviour
    {
        [SerializeField] private SpawnEnemy _spawnEnemy;
        
        public void DeactivateAllEnemies()
        {
            foreach (GameObject enemy in _spawnEnemy.GetEnemies())
            {
                enemy.SetActive(false); 
            }
        }
        
        public void ShowAllEnemies()
        {
            foreach (GameObject enemy in _spawnEnemy.GetEnemies())
            {
                enemy.SetActive(true); 
            }
        }
    }
}
