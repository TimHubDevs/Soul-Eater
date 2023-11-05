using SoulEater.Logic;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{

    [SerializeField] private GameObject SoulPrefab;
    [SerializeField] private Transform movePosit;
    [SerializeField] private float rangeDistance;
    [HideInInspector] public bool PlayerClose;
    [HideInInspector] public bool existInTriger;
    [HideInInspector] public bool startStalker;
    public float health = 10f;
    private NavMeshAgent _navMeshAgent;
    private Vector3 startPosition;
    

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

        if (existInTriger && startStalker)
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

            if (PlayerClose == true)
            {
                _navMeshAgent.destination = movePosit.position;
            }
            else if (rangeDistance < dist && transform.position != startPosition)
            {
                PlayerClose = false;
                _navMeshAgent.destination = startPosition;
            }
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
