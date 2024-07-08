using UnityEngine;

namespace RaidingParty
{
    public enum LandType { Water, Grass, Forest, Stone }
    public class LandAsset
    {
        private LandType landType;
        private Sprite sprite;

        public LandType LandType { get { return landType; } }
        public Sprite Sprite { get { return sprite; } }

        public LandAsset(LandType type, Sprite sprite)
        {
            this.landType = type;
            this.sprite = sprite;
        }
    }
}