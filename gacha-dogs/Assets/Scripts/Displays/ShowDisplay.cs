using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts
{
    public class ShowDisplay : MonoBehaviour
    {
        public ShowUpgradeList list;

        public GameObject nextButton;
        public GameObject previousButton;

        private PlayAudioSource _audio;

        private List<FacilityUpgrade> _showList;
        private FacilityUpgradeDisplay[] _displays;
        private int _index = 0;

        private void Awake()
        {
            _displays = GetComponentsInChildren<FacilityUpgradeDisplay>();
            _audio = GetComponentInChildren<PlayAudioSource>();

            _showList = new List<FacilityUpgrade>();
            _showList.AddRange(list.upgrades);
        }

        private void Start()
        {
            Populate();
        }

        public void Display()
        {
            for (int i = _index, j = 0; j < _displays.Length; i++, j++)
            {
                if (i < _showList.Count)
                {
                    _displays[j].SetFacilityUpgrade(_showList[i], i);
                }
                else
                {
                    _displays[j].SetFacilityUpgrade(null, -1);
                }
            }
        }

        public void Buy(FacilityUpgrade upgrade, int index)
        {
            if (PlayerManager.Instance.BuyFacility(upgrade))
            {
                _showList.RemoveAt(index); Populate();
                _audio.Play();
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
            if (_index + _displays.Length > _showList.Count - 1)
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
