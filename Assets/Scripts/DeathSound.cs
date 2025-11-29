using UnityEngine;

public class DeathSound : MonoBehaviour
{
    [SerializeField] private RandomSound deathSound;
    [SerializeField] private AudioSource audioSource;

    private void Awake()
    {
        deathSound.Play(audioSource);
    }
}