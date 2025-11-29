using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "RandomSound", menuName = "Scriptable Objects/RandomSound")]
public class RandomSound : ScriptableObject
{
    [SerializeField] private List<AudioClip> soundList;
    [SerializeField] private float volume = 1f;

    public void Play(AudioSource source)
    {
        Debug.Log("sound");
        AudioClip randomClip = soundList[Random.Range(0, soundList.Count)];
        source.PlayOneShot(randomClip, volume);
    }
    
}
