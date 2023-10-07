using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SoulEater.Logic
{
    public class Triger : MonoBehaviour
    {
        [SerializeField] private EnemyController Enemycontroler;
        // Start is called before the first frame update
        void Start()
        {

        }
        public void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                //Enemycontroler.PlayerClose = true;
            }
        }
        // Update is called once per frame
        void Update()
        {

        }
    }
}