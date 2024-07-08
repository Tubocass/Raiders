using UnityEngine;

namespace RaidingParty
{
    public enum BuildState { Clear, Finished, Building, Destroying }
    public enum BuildingType { Shelter, Production, Storage }

    public abstract class BuildingData
    {
        public LandData buildingLand;
        private BuildingAsset asset;
        private BuildState buildingState;
        private BuildingType type;
        private BuildState buildState;
        private LandData land;

        public BuildState CurrentBuildState { get { return buildingState; } }

        public BuildingData(BuildingAsset asset, BuildState buildState, LandData land) 
        {
            this.asset = asset;
            buildingState = buildState;
            buildingLand = land;
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