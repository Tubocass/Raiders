

namespace RaidingParty
{
    public class CellData
    {
        public enum LandType { Water, Grass, Forest, Stone }

        public LandType landType { get; }

        // Building plannedBuilding;
        // Building constructedBuilding;

        public CellData(LandType type)
        {
            landType = type;
        }
    }
}