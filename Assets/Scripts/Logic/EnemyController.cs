using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private GameObject SoulPrefab;
    public bool PlayerClose;
    [SerializeField] private Transform movePosit;
    public float health = 10f;
    private NavMeshAgent _navMeshAgent;
    
    void Start()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
    }

   
    void Update()
    {

        if (PlayerClose)
        {
            _navMeshAgent.destination = movePosit.position;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Sword"))
        {
            gameObject.SetActive(false);
            Instantiate(SoulPrefab, transform.position, SoulPrefab.transform.rotation);
        }
    }

    public void TakeDamage(float damage)
    {
        if (IsAttacking())
        {
            health -= damage;
            if (health <= 0)
            {
                Die();
            }
        }
    }


    private bool IsAttacking()
    {

        return false;
    }


    private void Die()
    {

        Destroy(gameObject);
    }
}
