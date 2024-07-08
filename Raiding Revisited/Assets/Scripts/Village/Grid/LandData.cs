using UnityEngine;

namespace RaidingParty
{
    public delegate void Changed();

    [System.Serializable]
    public class LandData
    {
        public event Changed TileChanged;
        LandAsset asset;
        //public bool IsOccupied = false;
        private BuildingData buildingData;

        public BuildingData BuildingData
        {
            get { return buildingData; }
            set { buildingData = value; TileChanged(); }
        }
        public LandType LandType { get { return asset.LandType; } }
        public Sprite Sprite { get { return asset.Sprite; } }

        public LandData() { }
        public LandData(LandAsset asset)
        {
            this.asset = asset;
        }

        public void ChangeLandType (LandAsset asset) 
        { 
            this.asset = asset;
            TileChanged();
        }

        public bool IsOccupied()
        {
            return BuildingData != null;
        }

    }
}