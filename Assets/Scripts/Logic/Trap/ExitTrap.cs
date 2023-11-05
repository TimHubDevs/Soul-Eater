using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitTrap : Trap
{
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            foreach (var Enemy in EnemiesWithTriger)
            {
                Enemy.startStalker = false;
            }
        }
    }
}
