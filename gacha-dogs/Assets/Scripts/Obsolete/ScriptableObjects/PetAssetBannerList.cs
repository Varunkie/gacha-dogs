using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts
{
    [CreateAssetMenu(menuName = "GameJam/PetAssetBannerList", fileName = "PetAssetBannerList1")]
    public class PetAssetBannerList : ScriptableObject
    {
        public PetAsset[] list;
    }
}
