using System.Collections;
using UnityEngine;

namespace RaidingParty
{
    public class GridGenerator : MonoBehaviour
    {
        public int width;
        public int length;
        Cell[,] grid;
        public Cell[,] GenerateGrid()
        {
            grid = new Cell[width, length];
            for (int w = 0; w < width; w++)
            {
                for (int l = 0; l < length; l++)
                {
                    grid[w, l] = new Cell(Cell.LandType.Grass);
                }
            }
            return grid;
        }
    }

    public class Cell
    {
        /*  LandType
         */
        public enum LandType { Water, Grass }
        LandType landType;
        public Cell(LandType type)
        {
            landType = type;
        }
        public LandType GetLandType()
        {
            return landType;
        }
        public void SetLandType(LandType type)
        {
            landType = type;
        }

        //public void SetBuilding() 
        //{ }
    }
}
