using UnityEngine;

public class SwordController : MonoBehaviour
{
    public float damage = 1f;
    public float attackreset= 1f;
    private bool canAttack = true;


    void Update()
    {
       
        if (canAttack)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Attack();
            }
        }
    }

   
    void Attack()
    {
     
        canAttack = false;
        Invoke("ResetAttackCooldown", attackreset);
    }

   
    void ResetAttackCooldown()
    {
        canAttack = true;
    }
}
