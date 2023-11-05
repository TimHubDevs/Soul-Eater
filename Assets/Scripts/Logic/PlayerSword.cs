using UnityEngine;

public class PlayerSword : MonoBehaviour
{
    public float damage = 1f;
    public bool dangerous = false;
    
    public void Attack()
    {
        dangerous = true;
    }
}
