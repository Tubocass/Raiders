using UnityEngine;

namespace RaidingParty
{
    public class CellController : MonoBehaviour
    {
        [SerializeField] SpriteMap spriteMap;
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
            spriteRenderer.sprite = spriteMap.spriteMap[landData.LandType];

            // update building
            if (landData.IsOccupied)
            {
                // draw building over land
            }
        }

        public void ChangeLandType (LandType newType)
        {
            landData.LandType = newType;
        }

        public void ChangeBuildingType(BuildingType newType)
        {
            buildingData.BuildingType = newType;
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
    }
}