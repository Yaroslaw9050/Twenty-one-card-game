using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Audio
{
    [RequireComponent(typeof(AudioSource))]
    public class GameFoneSoundComponent : MonoBehaviour
    {
        [SerializeField] private AudioClip audioClip;
        private AudioSource audioSource;
        public static GameFoneSoundComponent Instance;
        private void Awake()
        {
            audioSource = gameObject.GetComponent<AudioSource>();
            if(Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
                PlaySound();
            }
            else Destroy(gameObject);
        }
        private void PlaySound()
        {
            audioSource.playOnAwake = true;
            audioSource.loop = true;
            audioSource.clip = audioClip;
            audioSource.Play();
        }
    }
}
