using UnityEngine;

namespace RaidingParty
{
    public class Shelter : BuildingData
    {
        public int shelterAmount = 5;

        public Shelter(BuildingAsset asset, BuildState buildState, LandData land) : base(asset, buildState, land)
        {
        }
      
    }
}