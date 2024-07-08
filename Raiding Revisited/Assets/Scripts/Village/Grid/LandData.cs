using UnityEngine;

namespace RaidingParty
{
    public enum LandType { Water, Grass, Forest, Stone }

    public struct LandData
    {
        public LandType LandType;
        public BuildingData BuildSite;
        public bool isOccupied;

        public LandData(LandType landType) 
        {
            LandType = landType;
            BuildSite = null;
            isOccupied = false;
        }

        public void SetBuilding(BuildingData building)
        {
            BuildSite = building;
            isOccupied = true;
        }

        public void RemoveBuilding()
        {
            BuildSite = null;
            isOccupied = false;
        }
    }
}