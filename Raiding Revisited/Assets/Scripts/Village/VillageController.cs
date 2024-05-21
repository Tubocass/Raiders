using UnityEngine;

namespace RaidingParty
{
    public class VillageController : MonoBehaviour
    {
        [SerializeField] int width, height;

        VillageData villageData;
        GameGrid gameGrid;


        void CalcPopulation()
        {
            if (gameGrid != null)
            {
                foreach (LandData cell in gameGrid.Grid) 
                {
                    if(cell.BuildingData.BuildingType == BuildingType.Shelter)
                    {
                    }
                }
            }
        }
    }
}