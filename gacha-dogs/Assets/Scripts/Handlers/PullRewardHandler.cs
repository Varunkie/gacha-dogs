using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts
{
    public class PullRewardHandler : MonoBehaviour
    {
        public GameObject streetGameObject;
        public SpriteRenderer rewardImage;

        public AudioSource background;
        public ParticleSystem gachaParticle;

        private PlayAudioSource _audio;

        private void Awake()
        {
            rewardImage = GetComponent<SpriteRenderer>();
            _audio = GetComponentInChildren<PlayAudioSource>();
        }

        public void SetPull(PetAsset pet)
        {
            rewardImage.sprite = pet.sprite;

            if (!gachaParticle.isPlaying) gachaParticle.Play();
            _audio.Play();
        }

        private void OnMouseUp()
        {
            streetGameObject.SetActive(false);
            PlayerManager.Instance.MenuState = PlayerMenuState.Home;

            if (gachaParticle.isPlaying) gachaParticle.Stop();
        }
    }
}
