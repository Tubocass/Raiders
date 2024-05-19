using UnityEngine;

namespace RaidingParty
{
    public class GameController : MonoBehaviour
    {
        [SerializeField] int width, height;
        [SerializeField] GameObject protoCell;
        CellController[,] cellControllers;
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
            cellControllers = new CellController[width, height];

            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    cellControllers[x, y] = Instantiate(protoCell, new Vector3(x,y), Quaternion.identity, this.transform)
                        .GetComponent<CellController>();
                    cellControllers[x, y].SetData(gameGrid.Grid[x, y]);
                }
            }
        }

    }
} 