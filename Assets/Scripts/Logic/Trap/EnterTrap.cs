using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SoulEater.Logic
{
    public class EnterTrap : Trap
    { 
        protected override void Awake()
        {
           base.Awake();
        }

        public void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                foreach(var Enemy in EnemiesWithTriger)
                {
                    Enemy.startStalker = true;
                }
            }
        }
    }
}