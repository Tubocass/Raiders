namespace RaidingParty
{
    public enum LandType { Water, Grass, Forest, Stone }

    public class LandData
    {
        public LandType LandType { get; set; }

        public LandData(LandType type)
        {
            LandType = type;
        }

    }
}