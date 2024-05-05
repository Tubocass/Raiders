using UnityEngine;

namespace RaidingParty
{
    public class CellController : MonoBehaviour
    {
        CellData cellData;
        SpriteRenderer spriteRenderer;

        public void StartBuilding()
        {
            /*
             * params: buildType
             * set plannedBuilding with Building factory
            */
        }

        public void FinishBuilding()
        {
            /*
             * plannedBuilding becomes constructedBuilding
            */
        }
    }
}