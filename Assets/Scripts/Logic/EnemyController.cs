using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private GameObject SoulPrefab;
    [SerializeField] private Transform movePosit;
    [SerializeField] private float rangeDistance;
    [SerializeField] private float _attackDistance;
    [HideInInspector] public bool PlayerClose;
    [HideInInspector] public bool existInTriger;
    [HideInInspector] public bool startStalker;
    [SerializeField] public float health = 10f;
    private NavMeshAgent _navMeshAgent;
    private Vector3 startPosition;
    [SerializeField] private bool _canAttack;
    
    private void Start()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
        PlayerClose = false;
        Transform objTransform = transform;
        startPosition = objTransform.position;
    }

    private void Update()
    {
        float dist = Vector3.Distance(movePosit.position, transform.position);

        if (existInTriger && startStalker && !_canAttack)
        {
            _navMeshAgent.destination = movePosit.position;
        }
        else
        {
            if (rangeDistance >= dist)
            {
                PlayerClose = true;
            }
            else
            {
                PlayerClose = false;
            }

            if (PlayerClose && !_canAttack)
            {
                _navMeshAgent.destination = movePosit.position;
            }
            else if (rangeDistance < dist && transform.position != startPosition)
            {
                PlayerClose = false;
                _navMeshAgent.destination = startPosition;
            }
        }


        if (_canAttack)
        {
            _navMeshAgent.destination = transform.position;
            //TODO Attack Animation
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Sword") && other.gameObject.GetComponent<PlayerSword>().dangerous)
        {
            var playerSword = other.gameObject.GetComponent<PlayerSword>();
            Debug.Log("take damage" + playerSword.damage);
            playerSword.dangerous = false;
            health -= playerSword.damage;
            if (health <= 0)
            {
                gameObject.SetActive(false);
                Instantiate(SoulPrefab, transform.position, SoulPrefab.transform.rotation);
                Debug.Log("Die");
            }
        }
        
        if (other.gameObject.CompareTag("Player"))
        {
            _canAttack = true;
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

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            _canAttack = false;
        }
    }
}
