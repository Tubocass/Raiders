using System;
using UnityEngine;
using UnityEngine.UIElements;

namespace RaidingParty 
{
    public class TileInspector : MonoBehaviour
    {
        VisualElement root;
        Label landTypeLabel;
        Label buildTypeLabel;
        Label buildStateLabel;
        CellController selectedCell;


        private void OnEnable()
        {
            root = GetComponent<UIDocument>().rootVisualElement;
            landTypeLabel = root.Q<Label>(name: "label0");
            buildTypeLabel = root.Q<Label>(name: "label1");
            buildStateLabel = root.Q<Label>(name: "label2");

            SetupDropdown();
        }

        public void DisplayInfo(CellController cell)
        {
            selectedCell = cell;
            LandData selectedData = cell.GetLandData();
            landTypeLabel.text = selectedData.LandType.ToString();
            if (selectedData.IsOccupied())
            {
                buildTypeLabel.text = selectedData.BuildingData.BuildingType.ToString();
                buildStateLabel.text = selectedData.BuildingData.CurrentBuildState.ToString();
            }
        }

        void SetupDropdown()
        {
            DropdownField dropdown = root.Q<DropdownField>(name: "Options");
            dropdown.choices.Clear();
            foreach (string type in Enum.GetNames(typeof(LandType)))
            {
                dropdown.choices.Add(type);
            }

            dropdown.RegisterCallback<ChangeEvent<string>>(ChangeTile);
        }

        void ChangeTile(ChangeEvent<string> change)
        {
            if (selectedCell != null) 
            {
                selectedCell.ChangeLandType(Enum.Parse<LandType>(change.newValue));
            }
        }

    }
}
