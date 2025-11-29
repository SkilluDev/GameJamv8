using System;
using UnityEngine;

public class WinSound : MonoBehaviour
{
   [SerializeField] private RandomSound winSound;
   [SerializeField] private AudioSource audioSource;
   private void Awake()
   {
      winSound.Play(audioSource);
   }
}
