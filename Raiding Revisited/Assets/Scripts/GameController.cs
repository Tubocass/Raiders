using UnityEngine;

namespace RaidingParty
{
    public class GameController : MonoBehaviour
    {
        [SerializeField] VillageData homeVillage;
        VillageController villageController;
        VillageUI villageUI;
        InputController input;

        private void Start()
        {
            homeVillage.GenerateGrid();

            villageController = GetComponent<VillageController>();
            villageController.LoadVillage(homeVillage);
            //input.CellSelection += villageUI.HandleTileSelection();

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