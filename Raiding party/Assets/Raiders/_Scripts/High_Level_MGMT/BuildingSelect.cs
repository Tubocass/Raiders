using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;


public class BuildingSelect : MonoBehaviour
{
    [SerializeField] GameObject outline;
    [SerializeField] GameObject building;
    GameObject currentOutline;
    Collider outlineCollider;
    SpriteRenderer outlineSprite;
    Transform outlineTransform;
    bool isSelected;
    [SerializeField] LayerMask mask;
    RaycastHit m_hit;
    bool hitDetect;
    Color c_blocked = new Color(255, 0, 0, 0.75f);
    Color c_clear = new Color(255, 255, 255, 0.75f);


    public void SetOutline()
    {
        /*
            pass an index to the buildings array
        */
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if(currentOutline == null)
        {
            currentOutline = Instantiate(outline, new Vector3(mousePos.x, 0, mousePos.z), outline.transform.rotation);
            outlineCollider = currentOutline.GetComponentInChildren<Collider>();
            outlineSprite = currentOutline.GetComponentInChildren<SpriteRenderer>();
            outlineTransform = currentOutline.transform;
        }else{
            currentOutline.transform.position = new Vector3(mousePos.x, 0, mousePos.z);
            currentOutline.SetActive(true);
        }
        isSelected = true;
    }

    void Update() 
    {
        if(isSelected)
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            outlineTransform.position = new Vector3(mousePos.x, 3, mousePos.z);
            hitDetect = Physics.BoxCast(outlineCollider.bounds.center, outlineCollider.bounds.extents, -outlineTransform.up, out m_hit, outlineTransform.rotation, 10, mask);

            if(hitDetect)
            {
                Debug.Log("Hit : " + m_hit.collider.name);
                outlineSprite.color = c_blocked;
            }else{
                outlineSprite.color = c_clear;

            }
            if(Input.GetMouseButtonDown(0) && !hitDetect)
            {
                currentOutline.gameObject.SetActive(false);
                isSelected = false;
                GameObject go = Instantiate(building, outlineTransform.position - new Vector3(0, 3, 0), building.transform.rotation);
            }
            if(Input.GetMouseButtonDown(1))
            {
                currentOutline.gameObject.SetActive(false);
                isSelected = false;
            }
        }
    }
}
