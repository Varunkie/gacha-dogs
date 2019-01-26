using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts
{
    public class PetInventoryDisplay : MonoBehaviour
    {
        public GameObject nextButton;
        public GameObject previousButton;

        private PetAssetDisplay[] _displays;
        private int _index = 0;

        private List<PetAsset> Pets
        {
            get { return PlayerManager.Instance.PetInventory; }
        }

        private void Awake()
        {
            _displays = GetComponentsInChildren<PetAssetDisplay>();
        }

        private void Start()
        {
            Populate();
        }

        public void Display()
        {
            for (int i = _index, j = 0; j < _displays.Length; i++, j++)
            {
                if (i < Pets.Count)
                {
                    _displays[j].SetPetAsset(Pets[i], i);
                }
                else
                {
                    _displays[j].SetPetAsset(null, -1);
                }
            }
        }

        public void NextPage()
        {
            _index += _displays.Length; Populate();
        }

        public void PreviousPage()
        {
            _index -= _displays.Length; Populate();
        }

        public void Populate()
        {
            NextPageButtonEnabled();
            PrevPageButtonEnabled();
            Display();
        }

        private void NextPageButtonEnabled()
        {
            if (_index + _displays.Length > Pets.Count - 1)
                nextButton.SetActive(false);
            else
                nextButton.SetActive(true);
        }

        private void PrevPageButtonEnabled()
        {
            if (_index - 1 < 0)
                previousButton.SetActive(false);
            else
                previousButton.SetActive(true);
        }
    }
}
