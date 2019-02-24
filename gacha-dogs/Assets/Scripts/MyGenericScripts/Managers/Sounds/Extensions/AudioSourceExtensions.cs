using UnityEngine;

namespace SoundsManagement
{
    public static class AudioSourceExtensions
    {
        /// <summary>
        /// Set sounds parameters and audio clip to this audio source.
        /// </summary>
        public static void Assign(this AudioSource source, AudioSourceParameters parameters)
        {
            if (parameters != null)
                parameters.Assign(source);
        }

        /// <summary>
        /// Set sounds parameters to this audio source.
        /// </summary>
        public static void Setup(this AudioSource source, AudioSourceParameters parameters)
        {
            if (parameters != null)
                parameters.Setup(source);
        }

        /// <summary>
        /// Play a sound with given AudioSourceParameters.
        /// </summary>
        public static void Play(this AudioSource source, AudioSourceParameters parameters)
        {
            if (parameters != null)
            {
                source.Assign(parameters);
                source.Play();
            }
        }
    }
}
