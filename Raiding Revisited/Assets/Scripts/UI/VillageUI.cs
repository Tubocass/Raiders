using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UIElements;

namespace RaidingParty
{
    public class VillageUI : MonoBehaviour
    {
        Label villageName;
        Label foodAmount;
        Label populationAmount;
        Label treasureAmount;
        VillageData village;
        TileInspector tileInspector;


        void OnEnable()
        {
            VisualElement root = GetComponent<UIDocument>().rootVisualElement;
            villageName = root.Q<Label>(name: "locationName");
            foodAmount = root.Q<Label>(name: "foodAmount");
            populationAmount = root.Q<Label>(name: "populationAmount");
            treasureAmount = root.Q<Label>(name: "treasureAmount");
        }

        public void SetVillage(VillageData village)
        {
            this.village = village;
            villageName.text = village.locationName;
            foodAmount.text = village.foodAmount.ToString();
            populationAmount.text = village.populationAmount.ToString();
            treasureAmount.text = village.treasureAmount.ToString();
            RegisterIntChangeEvent(foodAmount, village.FoodAmountChnaged);
            RegisterIntChangeEvent(populationAmount, village.PopulationAmountChnaged);
            RegisterIntChangeEvent(treasureAmount, village.TreasureAmountChnaged);
        }

        void RegisterIntChangeEvent(Label label, UnityEvent<int> ev)
        {
            ev.AddListener(value => { label.text = value.ToString(); });
        }

        public void HandleTileSelection(CellController cell)
        {
            LandData land = cell.GetLandData();
            if (land.isOccupied)
            {
                // Display building's interface
            } else
            {
                DisplayBuildOptions(land.LandType);
            }
        }

        public void DisplayBuildOptions(LandType landType)
        {
            // get list of options based off landType
            // add a card for each build option available
            
            
        }
    }
}