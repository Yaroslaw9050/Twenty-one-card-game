using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Audio
{
    public class CardAudioComponent : AudioPlayerComponent
    {
        private void Start()
        {
            GameEventManager.Instance.OnCardSound.AddListener(PlayAudio);
        }
        public override void PlayAudio()
        {
            base.PlayAudio();
        }
    }
}
