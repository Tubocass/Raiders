using UnityEngine;

namespace RaidingParty
{
    public enum BuildState { Clear, Finished, Building, Destroying }
    public enum BuildingType { Shelter, Production, Storage }

    public abstract class BuildingData
    {
        private LandData buildSite;
        private BuildingAsset asset;
        private BuildState buildingState;
        private BuildingType type;
        public BuildingType Type { get { return type; } }

        public BuildState CurrentBuildState { get { return buildingState; } }

        public BuildingData(BuildingAsset asset, BuildState buildState, LandData land) 
        {
            this.asset = asset;
            buildingState = buildState;
            buildSite = land;
        }

        public void StartBuilding()
        {
            buildingState = BuildState.Building;
        }

        public void FinishBuilding()
        {
            buildingState = BuildState.Finished;
        }

        public void StartDestroying()
        {
            buildingState = BuildState.Destroying;
        }

        public void FinishDestroying()
        {
            buildingState = BuildState.Clear;
        }
    }
}