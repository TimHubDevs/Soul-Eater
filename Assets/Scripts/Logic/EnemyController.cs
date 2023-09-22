using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace SoulEater.Logic
{
    public class EnemyController : MonoBehaviour
    {
        //public bool playerClose;
        [SerializeField] float rangeDistance;
        [SerializeField] private Transform playerTransform;
        private NavMeshAgent navMeshAgent;

        void Start()
        {
            navMeshAgent = GetComponent<NavMeshAgent>();
        }

        void Update()
        {
            float dist = Vector3.Distance(playerTransform.position, transform.position);
            if(rangeDistance >= dist)
            {
                navMeshAgent.destination = playerTransform.position;
            }

            //if (playerClose)
            //{
                //navMeshAgent.destination = playerTransform.position;
            //}
        }
    }
}
