using UnityEngine;

namespace SoundsManagement
{
    [RequireComponent(typeof(AudioSource))]
    public class PlayAudioSource : BaseSoundController
    {
        public AudioSourceParameters _audio;
        public bool playOnAwake;

        protected override void Awake()
        {
            base.Awake();

            if (playOnAwake)
                Play();
        }

        public void Play()
        {
            if (_audio != null)
            {
                if (_audio._loop)
                    Play(_audio);
                else
                    PlayOneShot(_audio);
            }
        }
    }
}
