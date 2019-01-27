using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts
{
    [CreateAssetMenu(menuName = "GameJam/ShowUpgradeList", fileName = "ShowUpgradeList1")]
    public class ShowUpgradeList : ScriptableObject
    {
        public FacilityUpgrade[] upgrades;
    }
}
