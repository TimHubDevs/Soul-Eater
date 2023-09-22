using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SoulEater.Logic {
    public class TestCollider : MonoBehaviour
    {
        [SerializeField] private EnemyController enemyController;

    void Start()
        {

        }

        public void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                //enemyController.playerClose = true;
            }
        }

        void Update()
        {

        }
    }
}
