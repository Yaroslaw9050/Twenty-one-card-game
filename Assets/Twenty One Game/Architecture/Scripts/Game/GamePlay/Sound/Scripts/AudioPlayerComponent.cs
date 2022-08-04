using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Audio
{
    public class AudioPlayerComponent : MonoBehaviour
    {
        [SerializeField] private AudioClip[] audioClips;
        [Header("Audio Setting")]
        [Range(0f,1f)]
        [SerializeField] private float volume = 0.5f;
        [Range(0f,2f)]
        [SerializeField] private float pitch = 1f;
        public virtual void PlayAudio()
        {
            if(audioClips.Length == 0) {Debug.LogError("Miss AudioClip in:" + gameObject.name); return;} 

            StartCoroutine(PlayTine());

        }
        IEnumerator PlayTine()
        {
            AudioSource audioSource = gameObject.AddComponent<AudioSource>();
            audioSource.clip = audioClips[Random.Range(0, audioClips.Length)];
            audioSource.volume = this.volume;
            audioSource.pitch = this.pitch;
            float soundTime = audioSource.clip.length;
            audioSource.Play();

            yield return new WaitForSeconds(soundTime);
            Destroy(audioSource);
        }
    }
}
