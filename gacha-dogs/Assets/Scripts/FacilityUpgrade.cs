using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts
{
    [CreateAssetMenu(menuName = "GameJam/FacilityUpgrade", fileName="FacilityUpgrade1")]
    public class FacilityUpgrade : ScriptableObject
    {
        public Sprite sprite;
        public int coinBonusUp;
        public float coinBonusRateUp;
        public int loveBonusUp;
        public int coinCost;
        public int loveCost;
        [TextArea] public string description;
    }
}
