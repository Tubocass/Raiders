using UnityEngine.UIElements;

namespace RaidingParty
{
    public class BuildingCardDisplay : VisualElement
    {
        public BuildingCardDisplay(BuildingAsset buildingAsset)
        {
            VisualElement image = new VisualElement();
            image.style.backgroundImage = new StyleBackground(buildingAsset.Sprite);
            Label label = new Label(buildingAsset.name);

            AddToClassList("buildingOption");
            image.AddToClassList("buildingImage");
            label.AddToClassList("buildingLabel");

            Add(image);
            Add(label);
        }
    }
}