using UnityEngine;

namespace RaidingParty
{
    public class CellController : MonoBehaviour
    {
        [SerializeField] SpriteMap spriteMap;
        SpriteRenderer landRenderer;
        [SerializeField] SpriteRenderer buildingRenderer; //attached by prefab

        LandData landData;
        BuildingData buildingData;

        private void OnEnable()
        {
            landRenderer = GetComponent<SpriteRenderer>();
        }

        public void SetData(LandData data)
        {
            landData = data;
            UpdateSprite();
        }

        void UpdateSprite()
        {
            landRenderer.sprite = spriteMap.landSprites[landData.LandType];
            if(landData.isOccupied)
            {
                //buildingRenderer.sprite = spriteMap.buildingSprites[landData.BuildSite.Type];
            }
        }

        public LandData GetLandData()
        {
            return landData;
        }

        public void ChangeLandType (LandType newType)
        {
            //landData.LandType = newType;
        }

        public void SetBuildingData(BuildingData building)
        {
            buildingData = building;
        }

        public BuildingData GetBuildingData()
        {
            return buildingData;
        }
    }
}