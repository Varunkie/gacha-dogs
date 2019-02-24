using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts
{
    public class PetControllerDisplay : MonoBehaviour
    {
        private PetController[] _controller;

        public void Awake()
        {
            _controller = GetComponentsInChildren<PetController>();
        }

        private void Start()
        {
            Populate();
        }

        public void Populate()
        {
            if (PlayerManager.Instance != null)
            {
                for (int i = 0; i < _controller.Length; i++)
                {
                    if (i < PlayerManager.Instance.Pets.Count)
                    {
                        int index = PlayerManager.Instance.Pets[i];
                        PetAsset asset = PlayerManager.Instance.PetInventory[index];
                        _controller[i].SetPetAsset(asset);
                    }
                    else
                    {
                        _controller[i].SetPetAsset(null);
                    }
                }
            }
        }
    }
}
