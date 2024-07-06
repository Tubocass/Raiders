namespace RaidingParty
{
    public enum LandType { Water, Grass, Forest, Stone }

    public delegate void Changed();

    [System.Serializable]
    public class LandData
    {
        public event Changed TileChanged;
        public bool IsOccupied = false;
        public LandType LandType { get { return landType; } 
            set { landType = value; TileChanged(); } }
        //public BuildingData BuildingData { get { return buildingData; } 
        //    set { buildingData = value; TileChanged(); } }

        private LandType landType;
        //private BuildingData buildingData;

        public LandData(LandType type)
        {
            landType = type;
        }

        //public bool IsOccupied()
        //{
        //    return BuildingData != null;
        //}

    }
}