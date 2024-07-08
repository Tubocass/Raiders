using UnityEngine;

namespace RaidingParty
{
    [CreateAssetMenu]
    public class BuildingAsset : ScriptableObject
    {
        public BuildingType BuildingType { get; set; }
        [SerializeField] private Sprite sprite;
        public Sprite Sprite { get { return sprite; } }
        /*
         * animation for different stages
        */ 
    }
}