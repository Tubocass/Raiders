using UnityEngine;
using UnityEngine.UIElements;

namespace RaidingParty
{
    public class VillageDataUI : MonoBehaviour
    {
        public Label maxFood;
        public Label maxPopulation;
        public Label maxTreasure;

        public Label foodAmount;
        public Label populationAmount;
        public Label treasureAmount;
        VisualElement root;
        VillageData village;


        void Start()
        {
            root = GetComponent<UIDocument>().rootVisualElement;
            maxFood = root.Q<Label>(name: "maxFood");
            maxPopulation = root.Q(name: "Population").Q<Label>(name: "max");
            maxTreasure = root.Q<Label>(name: "maxTreasure");

        }

        public void SetVillage(VillageData village)
        {
            this.village = village;
            UpdateValues();
        }

        void UpdateValues()
        {
            maxFood.text = string.Format("{0} / {1}", village.foodAmount, village.maxFood);
            maxPopulation.text = string.Format("{0} / {1}", village.populationAmount, village.maxPopulation);
            maxTreasure.text = string.Format("{0} / {1}", village.treasureAmount, village.maxTreasure);
        }
    }
}