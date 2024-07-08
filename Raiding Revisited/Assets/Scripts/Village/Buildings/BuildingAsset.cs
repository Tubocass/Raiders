using System.Collections.Generic;
using UnityEngine;

namespace RaidingParty
{
    [CreateAssetMenu]
    public class BuildingAsset : ScriptableObject
    {
        [SerializeField] BuildingType buildingType;
        [SerializeField] private Sprite sprite;

        public Sprite Sprite { get { return sprite; } }
        public BuildingType BuildingType { get{ return buildingType; } }
        public List<LandType> validLandTypes = new List<LandType>();
        /*
         * animation for different stages
        */ 
    }
}