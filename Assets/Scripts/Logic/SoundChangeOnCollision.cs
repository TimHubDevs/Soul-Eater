using UnityEngine;

public class SoundChangeOnCollision : MonoBehaviour
{
    public AudioClip collisionSound;
    [SerializeField] private AudioSource audioSource;

    void OnCollisionEnter(Collision collision)
    {

        

        if (collision.gameObject.tag == "Player")
        {
            audioSource.Play();

            Debug.Log("Объект столкнулся с игроком");
        }
    }

}