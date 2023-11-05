using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{
    public List<EnemyController> EnemiesWithTriger = new List<EnemyController>();

    protected virtual void Awake()
    {
        foreach (var Enemy in EnemiesWithTriger)
        {
            Enemy.existInTriger = true;
        }
    }
}


