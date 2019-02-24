using System.Collections;
using UnityEngine;

namespace SoundsManagement
{
    /// <summary>
    /// Base class to defines a sound controller.
    /// </summary>
    [RequireComponent(typeof(AudioSource))]
    public class BaseSoundController : MonoBehaviour
    {
        protected AudioSource _source;
        private AudioSourceParameters _default;

        private float _volume;
        private float _pitch;
        private bool _loop;

        protected virtual void Awake()
        {
            _source = GetComponent<AudioSource>();
        }

        protected virtual void Start()
        {
            _volume = _source.volume;
            _pitch = _source.pitch;
            _loop = _source.loop;
        }

        /// <summary>
        /// Set the initial values of this audio source.
        /// </summary>
        private void Resetting()
        {
            _source.volume = _volume;
            _source.pitch = _pitch;
            _source.loop = _loop;
        }

        /// <summary>
        /// Auxiliar method to play a sound.
        /// </summary>
        protected void Play(AudioSourceParameters parameters)
        {
            if (parameters != null && parameters.Clip != null)
            {
                if (!parameters.UseDefaultValues)
                    _source.Play(parameters);
                else
                    Play(parameters.Clip);
            }
        }
        /// <summary>
        /// Auxiliar method to play a sound.
        /// </summary>
        protected void Play(AudioClip clip)
        {
            if (clip != null)
            {
                // Set initial values
                Resetting();

                // Play the sound
                _source.clip = clip;
                _source.Play();
            }
        }

        /// <summary>
        /// Auxiliar method to play one shot a sound.
        /// </summary>
        protected void PlayOneShot(AudioSourceParameters sound)
        {
            if (sound != null && sound.Clip != null)
            {
                _source.Setup(sound); PlayOneShot(sound.Clip, sound.Volume);
            }
        }

        /// <summary>
        /// Auxiliar method to play one shot a sound.
        /// </summary>
        protected void PlayOneShot(AudioClip clip, float volumeScale = 1f)
        {
            if (clip != null)
            {
                _source.PlayOneShot(clip, volumeScale);
            }
        }

        /// <summary>
        /// Auxiliar method to stop a sound.
        /// </summary>
        public void Stop()
        {
            _source.Stop();
        }
    }
}