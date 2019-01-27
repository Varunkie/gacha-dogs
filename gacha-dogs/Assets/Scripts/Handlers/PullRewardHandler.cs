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

        private void Awake()
        {
            rewardImage = GetComponent<SpriteRenderer>();
        }

        public void SetPull(PetAsset pet)
        {
            rewardImage.sprite = pet.sprite;
        }

        private void OnMouseUp()
        {
            streetGameObject.SetActive(false);
            PlayerManager.Instance.MenuState = PlayerMenuState.Home;
        }
    }
}
