using UnityEngine;

namespace RaidingParty
{
    public class VillageController : MonoBehaviour
    {
        [SerializeField] int width, height;
        [SerializeField] GameObject protoCell;
        CellController[,] cellDisplays;
        //Blackboard blackboard;
        [SerializeField] VillageData villageData;
        [SerializeField] VillageDataUI UIController;

        private void Start()
        {
            //GenerateBoard();
            //blackboard = new Blackboard();
        }

        public void GenerateBoard()
        {
            cellDisplays = new CellController[width, height];

            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    cellDisplays[x, y] = Instantiate(protoCell, new Vector3(x, y), Quaternion.identity, this.transform)
                        .GetComponent<CellController>();
                }
            }
        }

        public void LoadVillage(VillageData village)
        {
            villageData = village;
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    cellDisplays[x, y].SetData(villageData.AtLocation(x, y));
                }
            }
        }

        public void SetupHomeVillage()
        {
            /*
             * load home village into Village UI
            */
            UIController.SetVillage(villageData);
        }

       
    }
}