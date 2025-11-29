using UnityEngine;
using System.Collections;

public class PlayAndDie : MonoBehaviour
{
    [SerializeField] private RandomSound deathSound;
    [SerializeField] private AudioSource audioSource;
    private void Awake()
    {
        Debug.Log("PAD");
        deathSound.Play(audioSource);
        StartCoroutine(WaitToDie(2f));
    }

    private IEnumerator WaitToDie(float time)
    {
        yield return new WaitForSeconds(time);
        Destroy(gameObject);
        
    }
}
