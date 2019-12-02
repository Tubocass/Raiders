using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class GUIController : MonoBehaviour
{
    [SerializeField] LayerMask mask;
    TownController currentTown;
    List<Image> buildingImages = new List<Image>();
    [SerializeField] Text infoText;
    [SerializeField] Image imageFab;
    [SerializeField] GameObject slotPanel; 
    [SerializeField] Sprite farmSprite;
    [SerializeField] Sprite pastureSprite;
    [SerializeField] Sprite mineSprite;
    [SerializeField] Sprite weaponSmithSprite;
    [SerializeField] Sprite plusSprite;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, 100f, mask)) //!EventSystem.current.IsPointerOverGameObject() && 
            {
                if(hit.collider.tag.Equals("Town")){
                    currentTown = hit.transform.GetComponentInParent<TownController>();
                    this.infoText.text = currentTown.getTownInfo();
                    DisplayBuildings(currentTown.getBuildings());
                    // string[] parts = currentTown.getTownInfo().Split(',');
                }
            }

        }
    }
    void ClearBuildings()
    {
        buildingImages.ForEach((b) =>{Destroy(b.gameObject);});
        buildingImages.Clear();

    }
    void DisplayBuildings(ProductionSource[] buildings)
    {
        ClearBuildings();
        for(int i = 0; i<buildings.Length; i++)
        {
            Sprite imageSprite = null;

            switch(buildings[i].resourceType)
            {
                case ProductionSource.Resource.Food:
                {
                    if(buildings[i].isActive)
                    {
                        imageSprite = pastureSprite;
                    }else{
                        imageSprite = plusSprite;
                    }
                    break;
                }
            }
            Image building = Instantiate(imageFab, Vector3.zero,                imageFab.transform.rotation);
            building.sprite = imageSprite;
            building.transform.SetParent(this.slotPanel.transform);
            buildingImages.Add(building);
        }
        RectTransform t = slotPanel.transform as RectTransform;
        t.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 55 * buildingImages.Count);
   }
}
