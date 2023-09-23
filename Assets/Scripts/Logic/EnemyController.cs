using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private GameObject SoulPrefab; 
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Sword"))
        {
            gameObject.SetActive(false);
            Instantiate(SoulPrefab, transform.position, SoulPrefab.transform.rotation);
        }
    }
}
