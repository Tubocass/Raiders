using UnityEngine;
using UnityEngine.UIElements;

namespace RaidingParty 
{
    public class Inspector : MonoBehaviour
    {
        /*
         * recieve an item, such as a building or character, and display it's information in UI
        */
        VisualElement root;
        Label landTypeLabel;
        Label buildTypeLabel;
        Label buildStateLabel;


        private void OnEnable()
        {
            root = GetComponent<UIDocument>().rootVisualElement;
            landTypeLabel = root.Q<Label>(name: "label0");
            buildTypeLabel = root.Q<Label>(name: "label1");
            buildStateLabel = root.Q<Label>(name: "label2");
        }

        public void DisplayInfo(CellController cd)
        {
            landTypeLabel.text = cd.GetLandData().LandType.ToString();
            BuildingData bd = cd.GetBuildingData();
            if(bd != null)
            {
                buildTypeLabel.text = bd.BuildingType.ToString();
                buildStateLabel.text = bd.CurrentBuildState.ToString();
            }
        }
    }
}
