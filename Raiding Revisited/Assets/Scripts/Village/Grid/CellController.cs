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
            landData.TileChanged += UpdateSprite;
            UpdateSprite();
        }

        void UpdateSprite()
        {
            // update land
            landRenderer.sprite = landData.Sprite;

            // update building
            if (landData.IsOccupied())
            {
                // draw building over land
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

        //public void ChangeBuildingType(BuildingType newType)
        //{
        //    buildingData.BuildingType = newType;
        //}

    }
}