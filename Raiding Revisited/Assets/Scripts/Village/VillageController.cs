using UnityEngine;

namespace RaidingParty
{
    public class VillageController : MonoBehaviour
    {
        [SerializeField] GameObject protoCell;
        [SerializeField] VillageData villageData;
        [SerializeField] VillageUI UIController;
        CellController[,] cellDisplays;

        public void LoadVillage(VillageData village)
        {
            villageData = village;
            UIController.SetVillage(villageData);
            GenerateBoard(village.width, village.height);

            for (int x = 0; x < village.width; x++)
            {
                for (int y = 0; y < village.height; y++)
                {
                    cellDisplays[x, y].SetData(villageData.AtLocation(x, y));
                }
            }
        }

        void GenerateBoard(int width, int height)
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

        public void UnloadVillage()
        {

        }

        public void ProduceResources()
        {

        }

    }
}