using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class GUIController : MonoBehaviour
{
    [SerializeField] LayerMask mask;
//     [SerializeField] GameObject panelFab;
//     [SerializeField] Canvas canvas;
//     PanelController panel;
//     [SerializeField] GameObject raidPanel;
//     RaidPrompt raidPrompt;
    TownInfo currentTown;
    [SerializeField] Text infoText;
    [SerializeField] Image imageFab;
    [SerializeField] GameObject slotPanel; 
    [SerializeField] Sprite farmSprite;
    [SerializeField] Sprite pastureSprite;
    [SerializeField] Sprite mineSprite;
    [SerializeField] Sprite weaponSmithSprite;
    List<ProductionSource> productions;


    // Start is called before the first frame update
    void Start()
    {
        // GameObject raidUI = Instantiate(raidPanel, Vector3.zero, Quaternion.identity);
        // raidUI.transform.SetParent(canvas.transform, false);
        // raidPrompt = raidUI.GetComponent<RaidPrompt>();
        // raidPrompt.HidePanel();
        // GameObject panelUI = Instantiate(panelFab, Vector3.zero, Quaternion.identity);
        // panelUI.transform.SetParent(canvas.transform, false);
        // panelUI.transform.SetAsLastSibling();
        // panel = panelUI.GetComponent<PanelController>();
        // panel.HidePanel();
    }

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
                    currentTown = hit.transform.GetComponent<TownInfo>();
                    this.infoText.text = currentTown.getTownInfo();
                    DisplayBuildings(currentTown);
                    // string[] parts = currentTown.getTownInfo().Split(',');
                }
            }

        }
    }
   void DisplayBuildings(TownInfo town)
   {
       this.productions = town.getProductionSources();
       Sprite imageSprite = null;
       for(int i = 0; i<productions.Count; i++)
       {
           switch(productions[i].resourceType)
           {
               case ProductionSource.Resource.Food:
               {
                   imageSprite = farmSprite;
                   break;
               }
                case ProductionSource.Resource.Wood:
               {
                   imageSprite = mineSprite;
                   break;
               }
                case ProductionSource.Resource.Weapon:
               {
                   imageSprite = weaponSmithSprite;
                   break;
               }
           }
            Image building = Instantiate(imageFab, Vector3.zero, imageFab.transform.rotation);
            building.sprite = imageSprite;
            building.transform.SetParent(this.slotPanel.transform);
       }
      
   }
}
