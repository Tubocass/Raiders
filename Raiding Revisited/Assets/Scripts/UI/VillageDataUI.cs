using UnityEngine;
using UnityEngine.UIElements;

namespace RaidingParty
{
    public class VillageDataUI : MonoBehaviour
    {
        //public Label maxFood;
        //public Label maxPopulation;
        //public Label maxTreasure;

        public Label foodAmount;
        public Label populationAmount;
        public Label treasureAmount;
        VisualElement root;
        VillageData village;


        void Start()
        {
            root = GetComponent<UIDocument>().rootVisualElement;
            foodAmount = root.Q<Label>(name: "foodAmount");
            populationAmount = root.Q<Label>(name: "populationAmount");
            treasureAmount = root.Q<Label>(name: "treasureAmount");

        }

        public void SetVillage(VillageData village)
        {
            this.village = village;
            UpdateValues();
        }

        void UpdateValues()
        {
            //foodAmount.text = string.Format("{0} / {1}", village.foodAmount, village.maxFood);
            //populationAmount.text = string.Format("{0} / {1}", village.populationAmount, village.maxPopulation);
            //treasureAmount.text = string.Format("{0} / {1}", village.treasureAmount, village.maxTreasure);
        }
    }
}