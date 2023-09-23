using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace SoulEater.Logic
{
    public class EnemyController : MonoBehaviour
    {
        private Vector3 startPosition;
        //public bool playerClose;
        [SerializeField] float rangeDistance;
        [SerializeField] private Transform playerTransform;
        private NavMeshAgent navMeshAgent;

        void Start()
        {
            navMeshAgent = GetComponent<NavMeshAgent>();
        }

        private void OnEnable()
        {
            startPosition = transform.position;
        }

        void Update()
        {
            float dist = Vector3.Distance(playerTransform.position, transform.position);
            if(rangeDistance >= dist)
            {
                navMeshAgent.destination = playerTransform.position;
            }
            else if(rangeDistance < dist && transform.position != startPosition)
            {
                navMeshAgent.destination = startPosition;
            }

            //if (playerClose)
            //{
                //navMeshAgent.destination = playerTransform.position;
            //}
        }
    }
}
