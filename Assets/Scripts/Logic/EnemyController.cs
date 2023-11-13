using System.Collections.Generic;
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
    private Animator animator;
    private List<string> animations;
    [SerializeField] private bool _canAttack;
    
    private void Start()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
        PlayerClose = false;
        Transform objTransform = transform;
        startPosition = objTransform.position;
        animator = GetComponent<Animator>();
        animations = new List<string>()
            {
                "Hit1",
                "Fall1",
                "Attack1h1",
                "Walk",
                "Idle",
            };
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
                animator.SetBool("IsWalking",true);
            }
            else
            {
                PlayerClose = false;
                animator.SetBool("IsWalking", false);
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
            animator.SetBool("IsAtacking", true);
        }

        else
        {
            animator.SetBool("IsAtacking", false);
        }
    }

    public void hit()
    {
        animator.SetBool("Hit", false);
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
            animator.SetBool("Hit", true);
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
                animator.SetBool("Fall", true);
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
