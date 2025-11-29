using UnityEngine;
using System.Collections;

public class ExplosionSound : MonoBehaviour
{
    [SerializeField] private RandomSound explosionSound;
    [SerializeField] private AudioSource audioSource;
    private void Awake()
    {
        explosionSound.Play(audioSource);
        StartCoroutine(WaitToDie(2f));
    }

    private IEnumerator WaitToDie(float time)
    {
        yield return new WaitForSeconds(time);
        Destroy(gameObject);
        
    }
}
