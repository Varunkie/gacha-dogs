using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using SoundsManagement;

namespace EditorScripts
{
    [CustomEditor(typeof(AudioSourceParameters))]
    [CanEditMultipleObjects]
    public class AudioSourceParametersEditor : Editor
    {
        private static AudioSource _instance;
        private AudioSourceParameters _target;

        public bool Playing
        {
            get { return _instance.isPlaying && _instance.loop; }
        }

        private void OnEnable()
        {
            _target = (AudioSourceParameters)target;

            if (_instance == null)
                Create();
        }

        private void Create()
        {
            _instance = new GameObject("Editor Audio Source").AddComponent<AudioSource>();
            _instance.hideFlags = HideFlags.HideAndDontSave;
        }

        public override void OnInspectorGUI()
        {
            if (_target != null)
            {
                DefaultPropertiesInspector();
                PlayAudioInspector();
                SaveInspector();
            }
        }

        #region Inspector Methods
        private void DefaultPropertiesInspector()
        {
            EditorGUILayout.Space();

            _target._clip = (AudioClip)EditorGUILayout.ObjectField("Clip: ", _target._clip, typeof(AudioClip), false);

            EditorGUILayout.Space();
            EditorGUILayout.BeginVertical("BOX");
            {
                if (Playing)
                    GUI.enabled = false;

                EditorGUILayout.Space();
                if (!_target._useDefaultValues)
                {
                    _target._volume = EditorGUILayout.Slider("   Volume: ", _target._volume, 0f, 1f);
                    _target._pitch = EditorGUILayout.Slider("   Pitch: ", _target._pitch, -3f, 3f);
                    _target._loop = EditorGUILayout.Toggle("   Loopable: ", _target._loop);
                }
                _target._useDefaultValues = EditorGUILayout.Toggle("   Use default values: ", _target._useDefaultValues);
                EditorGUILayout.Space();

                if (Playing)
                    GUI.enabled = true;
            }
            EditorGUILayout.EndVertical();
            EditorGUILayout.Space();
        }

        private void PlayAudioInspector()
        {
            if (!Playing)
            {
                EditorGUI.BeginDisabledGroup(_target.Clip == null);
                if (GUILayout.Button("Play Audio"))
                {
                    if (_target._clip != null && _instance != null)
                    {
                        // Setup
                        if (!_target._useDefaultValues)
                        {
                            _instance.pitch = _target._pitch;
                            _instance.volume = _target._volume;
                            _instance.loop = _target._loop;
                        }
                        else
                        {
                            _instance.pitch = 1f;
                            _instance.volume = 1f;
                            _instance.loop = false;
                        }
                        _instance.clip = _target._clip;

                        // Play
                        if (!_instance.loop)
                            _instance.PlayOneShot(_instance.clip);
                        else
                            _instance.Play();
                    }
                }
                EditorGUI.EndDisabledGroup();
            }
            else
            {
                if (GUILayout.Button("Stop Audio"))
                {
                    if (_instance != null)
                    {
                        _instance.Stop();
                    }
                }
            }
        }
        #endregion

        private void SaveInspector()
        {
            if (GUI.changed)
            {
                EditorUtility.SetDirty(target);
            }
        }
    }
}