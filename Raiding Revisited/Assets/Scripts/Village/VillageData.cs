using UnityEngine;

namespace RaidingParty
{
    [System.Serializable]
    [CreateAssetMenu]
    public class VillageData : ScriptableObject
    {
        public string locationName;
        //public int maxFood;
        //public int foodAmount;
        //public int maxPopulation;
        public int populationAmount;
        //public int treasureAmount;

        [SerializeField] int width, height;
        LandData[,] grid;
        //public LandData[,] Grid { get { return grid; } }
        //List<LandData> landSquares;
        //List<BuildingData> buildings;
        //List<ItemStack> resources;

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