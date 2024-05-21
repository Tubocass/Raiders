using UnityEngine;

namespace RaidingParty
{
    public class Shelter : BuildingData, BuildingInterface
    {
        public int shelterAmount = 5;

        public Shelter(BuildingType type, BuildState buildState) : base(type, buildState)
        {
        }

        public void StartBuilding()
        {
            CurrentBuildState = BuildState.Building;
        }

        public void FinishBuilding()
        {
            CurrentBuildState = BuildState.Occupied;
        }

        public void StartDestroying()
        {
            CurrentBuildState = BuildState.Destroying;
        }

        public void FinishDestroying()
        {
            CurrentBuildState = BuildState.Clear;
        }
    }
}