using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputControl : MonoBehaviour
{
    [SerializeField] Camera mainCamera;
    [SerializeField] GameObject selection;
    [SerializeField] Character selectedUnit;
    

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 point = mainCamera.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(point, mainCamera.transform.forward);
            if(hit.collider != null)
            {
                selection = hit.collider.gameObject;
                if (selection.GetComponent<Character>() != null)
                {
                    selectedUnit = selection.GetComponent<Character>();
                }
            }
        }

        if (selectedUnit != null && Input.GetMouseButtonDown(1))
        {
            Vector2 point = mainCamera.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(point, mainCamera.transform.forward);
            if (hit.collider != null)
            {
                Building building = hit.collider.GetComponent<Building>();
                if (building != null)
                {
                    building.AssignWorker(selectedUnit);
                }
            }
            selectedUnit.MoveTo(point);
        }
    }
}
