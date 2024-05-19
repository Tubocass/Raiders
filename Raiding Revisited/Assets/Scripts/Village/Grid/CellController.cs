using UnityEngine;

namespace RaidingParty
{ 
    public class CellController : MonoBehaviour
    {
        [SerializeField] SpriteMap cellDisplay;
        SpriteRenderer spriteRenderer;

        LandData landData;
        BuildingData buildingData;

        private void OnEnable()
        {
            spriteRenderer = GetComponent<SpriteRenderer>();
        }

        public void SetData(LandData data)
        {
            landData = data;
            landData.TileChanged += UpdateSprite;
            UpdateSprite();
        }

        void UpdateSprite()
        {
            // update land
            spriteRenderer.sprite = cellDisplay.spriteMap[landData.LandType];

            // update building
            if (landData.IsOccupied())
            {
                // draw building over land
            }
        }

        public void ChangeTile (LandType newType)
        {
            landData.LandType = newType;
        }


        public LandData GetLandData()
        {
            return landData;
        }

        public BuildingData GetBuildingData()
        {
            return buildingData;
        }

        public void SetBuildingData(BuildingData building)
        {
            buildingData = building;
        }

        public void StartBuilding()
        {
           buildingData.CurrentBuildState = BuildState.Building;
        }

        public void FinishBuilding()
        {
            buildingData.CurrentBuildState = BuildState.Occupied;
        }
    }
}