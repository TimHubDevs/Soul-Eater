using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private GameObject soulPrefab;
    private Vector3 startPosition;
    [SerializeField] private float rangeDistance = 5;
    [SerializeField] private Transform playerTransform;
    private NavMeshAgent navMeshAgent;

    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        startPosition = transform.position; // Initialize startPosition here
        playerTransform = GameObject.Find("Player").transform;
    }

    void Update()
    {
        float dist = Vector3.Distance(playerTransform.position, transform.position);

        if (rangeDistance <= dist)
        {
            navMeshAgent.destination = playerTransform.position;
        }
        else if (rangeDistance > dist && transform.position != startPosition)
        {
            navMeshAgent.destination = startPosition;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Sword"))
        {
            gameObject.SetActive(false);
            Instantiate(soulPrefab, transform.position, soulPrefab.transform.rotation);
        }
    }
}
