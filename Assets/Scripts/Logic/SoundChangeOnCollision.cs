using UnityEngine;

public class SoundChangeOnCollision : MonoBehaviour
{
    public AudioClip collisionSound;
    [SerializeField] private AudioSource audioSource;

    private void Start()
    {
        audioSource.clip = collisionSound;
    }

    private void OnTriggerEnter(Collider other)
    {
            if (other.gameObject.CompareTag("Player"))
            {
                audioSource.Play();
            }
    }
}
