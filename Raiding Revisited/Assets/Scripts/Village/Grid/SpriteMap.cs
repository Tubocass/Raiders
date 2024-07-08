using System.Collections.Generic;
using UnityEngine;

namespace RaidingParty {
    [CreateAssetMenu]
    public class SpriteMap : ScriptableObject
    {
        public Sprite grass;
        public Sprite forest;
        public Sprite stone;
        public Sprite water;
        public Dictionary<LandType, Sprite> landSprites;
        public Dictionary<BuildingType, Sprite> buildingSprites;


        private void OnEnable()
        {
            landSprites = new Dictionary<LandType, Sprite>
        {
            { LandType.Grass, grass },
            { LandType.Water, water },
            { LandType.Forest, forest },
            { LandType.Stone, stone }
        };

            buildingSprites = new Dictionary<BuildingType, Sprite>
            {

            };
        }
    }
}
