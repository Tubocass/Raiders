using UnityEngine;

namespace RaidingParty
{
    public class GameController : MonoBehaviour
    {
        [SerializeField] int width, height;
        [SerializeField] GameObject protoCell;
        CellController[,] cellDisplays;
        //Blackboard blackboard;
        GameGrid gameGrid;
        VillageData villageData;
        //string board = "board";

        private void Start()
        {
            GenerateBoard();
            //blackboard = new Blackboard();
        }

        public void GenerateBoard()
        {
            gameGrid = new GameGrid(width, height);
            gameGrid.GenerateGrid();
            cellDisplays = new CellController[width, height];

            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    cellDisplays[x, y] = Instantiate(protoCell, new Vector3(x,y), Quaternion.identity, this.transform)
                        .GetComponent<CellController>();
                    cellDisplays[x, y].SetData(gameGrid.Grid[x, y]);
                }
            }
        }

        public void SetupHomeVillage()
        {
            /*
             * load home village into Village UI
            */
        }

        public void AdvanceTime()
        {
            /*
             * basically a FSM
             * when the season changes - resources are harvested, taxes and tributes are paid, troops finish training
            */
        }

    }
} 