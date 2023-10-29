using UnityEngine;

public class SoundChangeOnCollision : MonoBehaviour
{
    public AudioClip collisionSound;
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = collisionSound;
    }

    private void OnTriggerEnter(Collider other)
    {
            if (other.gameObject.CompareTag("Player"))
            {
                audioSource.Play();
                Debug.Log("смена");
            }
    }
}
