using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts
{
    [CreateAssetMenu(menuName = "GameJam/PetAsset", fileName = "PetAsset1")]
    public class PetAsset : ScriptableObject
    {
        public int loveUp;
        public int coinUp;
        [TextArea] public string description;
        public Sprite sprite;
        public Sprite face;
    }
}
