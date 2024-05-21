

namespace RaidingParty
{
    public enum BuildState { Clear, Occupied, Building, Destroying }
    public enum BuildingType { Shelter, Production, Storage }

    public class BuildingData 
    {
        public BuildingType BuildingType { get; set; }

        public BuildState CurrentBuildState { get; set; }

        public BuildingData(BuildingType type , BuildState buildState) 
        {
            BuildingType = type;
            this.CurrentBuildState = buildState; 
        }
    }
}