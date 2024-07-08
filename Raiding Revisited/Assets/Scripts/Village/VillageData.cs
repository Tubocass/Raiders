using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UIElements;

namespace RaidingParty
{
    [System.Serializable]
    [CreateAssetMenu]
    public class VillageData : ScriptableObject
    {
        public string locationName;
        public int foodAmount;
        public int populationAmount;
        public int treasureAmount;

        public int width, height;
        LandData[,] grid;
        public UnityEvent<int> FoodAmountChnaged;
        public UnityEvent<int> PopulationAmountChnaged;
        public UnityEvent<int> TreasureAmountChnaged;


        private void OnEnable()
        {
    
        }

        public void GenerateGrid()
        {
            grid = new LandData[width, height];
            for (int w = 0; w < width; w++)
            {
                for (int h = 0; h < height; h++)
                {
                    grid[w, h] = new LandData();
                }
            }
        }

        public LandData AtLocation(int x, int y)
        {
            return grid[x, y];
        }

    }
}