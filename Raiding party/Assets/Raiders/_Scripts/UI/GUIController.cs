using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class GUIController : MonoBehaviour
{
    [SerializeField] LayerMask mask;
    TownController currentTown;
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
                    currentTown = hit.transform.GetComponentInParent<TownController>();
                    this.infoText.text = currentTown.getTownInfo();
                    DisplayBuildings(currentTown.getBuildings());
                    // string[] parts = currentTown.getTownInfo().Split(',');
                }
            }

        }
    }
   void DisplayBuildings(ProductionSource[] buildings)
   {
       Sprite imageSprite = null;
      
       for(int i = 0; i<buildings.Length; i++)
       {
           switch(buildings[i].resourceType)
           {
               case ProductionSource.Resource.Food:
               {
                   if(buildings[i].isActive)
                   {
                       imageSprite = pastureSprite;
                   }else
                   {
                       imageSprite = farmSprite;
                   }
                   break;
               }
           }
            Image building = Instantiate(imageFab, Vector3.zero, imageFab.transform.rotation);
            building.sprite = imageSprite;
            building.transform.SetParent(this.slotPanel.transform);

       }
    //        switch(productions[i].resourceType)
    //        {
    //            case ProductionSource.Resource.Food:
    //            {
    //                imageSprite = farmSprite;
    //                break;
    //            }
    //             case ProductionSource.Resource.Material:
    //            {
    //                imageSprite = mineSprite;
    //                break;
    //            }
    //             case ProductionSource.Resource.Craft:
    //            {
    //                imageSprite = weaponSmithSprite;
    //                break;
    //            }
    //        }
    //    }
      
   }
}
