using UnityEngine;

public class SoundChangeOnCollision : MonoBehaviour
{
    public AudioClip collisionSound;
    [SerializeField] private AudioSource audioSource;

    private void OnTriggerEnter(Collider other)
    {
            if (other.gameObject.CompareTag("Player"))
            {
                if (audioSource.clip != collisionSound)
                {
                    audioSource.clip = collisionSound;
                    audioSource.Play();
                }
            }
    }
}
