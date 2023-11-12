using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RaidingParty.Buildings;
using RaidingParty.Resources;

namespace RaidingParty
{
    public class GameController : MonoBehaviour
    {
        //public GridGenerator gridGenerator;
        //Cell[,] grid;
        //CellDisplay[,] cellDisplays;
        //public Sprite testSprite;
        //public Dictionary<Cell.LandType, Sprite> spriteDictionary = new Dictionary<Cell.LandType, Sprite>();
        //public void Generate()
        //{
        //    grid = gridGenerator.GenerateGrid();
        //    cellDisplays = new CellDisplay[gridGenerator.width, gridGenerator.length];
        //    for (int w = 0; w < grid.GetLength(0); w++)
        //    {
        //        for (int l = 0; l < grid.GetLength(1); l++)
        //        {
        //            cellDisplays[w, l] = new CellDisplay();
        //        }
        //    }
        //}
        //public void UpdateDisplay()
        //{
        //    for (int w = 0; w < grid.GetLength(0); w++)
        //    {
        //        for (int l = 0; l < grid.GetLength(1); l++)
        //        {
        //            cellDisplays[w, l] = new CellDisplay();
        //        }
        //    }
        //}

        [SerializeField] ResourceBuilding resource;
        [SerializeField] StorageBuilding storage;
        [SerializeField] ProductionBuilding production;

        public void TestStorage()
        {
            storage.Store(resource.Produce());
        }

        public void TestProduction()
        {
        }

    }
}