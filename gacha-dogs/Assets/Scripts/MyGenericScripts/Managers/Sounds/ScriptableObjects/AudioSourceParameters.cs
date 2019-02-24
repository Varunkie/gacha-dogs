using UnityEngine;

namespace SoundsManagement
{
    [CreateAssetMenu(menuName = "3DAvenue/Sounds/AudioSourceParameters", fileName = "AudioSourceParameters")]
    public class AudioSourceParameters : ScriptableObject
    {
        public AudioClip _clip;
        public float _volume = 1f;
        public float _pitch = 1f;
        public bool _loop = false;
        public bool _useDefaultValues = true;

        #region Properties
        /// <summary>
        /// Returns the audio clip attached to this sound parameters.
        /// </summary>
        public AudioClip Clip
        {
            get { return _clip; }
        }

        /// <summary>
        /// When true, this audio should use the default values of audio source.
        /// </summary>
        public bool UseDefaultValues
        {
            get { return _useDefaultValues; }
        }

        /// <summary>
        /// Returns the volume scale of this audio clip.
        /// </summary>
        public float Volume
        {
            get { return _volume; }
        }
        #endregion

        /// <summary>
        /// Set the values of given audio source to this parameters.
        /// </summary>
        public void Initialize(AudioSource source)
        {
            _volume = source.volume;
            _pitch = source.pitch;
            _loop = source.loop;
            _clip = source.clip;
        }

        /// <summary>
        /// Set to given audio source this sound parameters and set the attached audio clip.
        /// </summary>
        public void Assign(AudioSource source)
        {
            Setup(source); source.clip = _clip;
        }

        /// <summary>
        /// Set to given audo source this sound parameters.
        /// </summary>
        public void Setup(AudioSource source)
        {
            source.volume = _volume;
            source.pitch = _pitch;
            source.loop = _loop;
        }
    }
}