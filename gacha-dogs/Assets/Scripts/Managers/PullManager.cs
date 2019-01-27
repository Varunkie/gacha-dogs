using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts
{
    public class PullManager : MonoBehaviour
    {
        public PetAssetBannerList banner;
        private List<PetAsset> _pullList;
        public float dificultyRate = 1.2f;


        public static PullManager Instance
        {
            get;
            private set;
        }

        public int Cost
        {
            get;
            private set;
        }

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                _pullList = new List<PetAsset>();
                Cost = 100;
                DontDestroyOnLoad(this);
            }
            else
                Destroy(this);
        }

        private void Start()
        {
            if (banner != null)
                _pullList.AddRange(banner.list);
        }

        public PetAsset Pull()
        {
            if (PlayerManager.Instance.Love >= Cost)
            {
                PlayerManager.Instance.RemoveLove(Cost);
                PetAsset pet = GeneratePull();
                PlayerManager.Instance.PetInventory.Add(pet);
                Cost = (int)(Cost * dificultyRate);
                return pet;
            }
            return null;
        }

        private PetAsset GeneratePull()
        {
            int index = UnityEngine.Random.Range(0, _pullList.Count);
            return _pullList[index];
        }
    }
}
