using UnityEngine;
using System.Collections.Generic;
using TMPro;
using UnityEngine.UI;

namespace Assets.Scripts
{
    public class GoingToStreetButtonHandler : MonoBehaviour
    {
        public GameObject pullGameObject;
        public GameObject streetGameObject;
        public PullRewardHandler _pullReward;
        public Text loveCost;
        public PlayOneShotAudioSource playAudio;

        private void OnEnable()
        {
            loveCost.text = PullManager.Instance.Cost.ToString();
        }

        public void GoingToStreet()
        {
            if (PlayerManager.Instance.Love >= PullManager.Instance.Cost)
            {
                PlayerManager.Instance.MenuState = PlayerMenuState.Pulling;
                PetAsset pull = PullManager.Instance.Pull();
                streetGameObject.SetActive(true);
                pullGameObject.SetActive(false);
                _pullReward.SetPull(pull);
            }
            else
            {
                playAudio.Play();
            }
        }
    }
}
