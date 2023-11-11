using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RaidingParty
{
    public class InputControl : MonoBehaviour
    {
        [SerializeField] Camera mainCamera;
        [SerializeField] GameObject selection;
        [SerializeField] Character selectedUnit;
        [SerializeField] float speed = 20;
        Vector3 movement;
        Vector2 point;
        RaycastHit2D hit;

        void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                point = mainCamera.ScreenToWorldPoint(Input.mousePosition);
                hit = Physics2D.Raycast(point, mainCamera.transform.forward);
                if (hit.collider != null)
                {
                    selection = hit.collider.gameObject;
                    if (selection.GetComponent<Character>() != null)
                    {
                        selectedUnit = selection.GetComponent<Character>();
                    }
                }
            }

            if (Input.GetMouseButton(0))
            {

            }
            if (selectedUnit != null && Input.GetMouseButtonDown(1))
            {
                point = mainCamera.ScreenToWorldPoint(Input.mousePosition);
                hit = Physics2D.Raycast(point, mainCamera.transform.forward);
                if (hit.collider != null)
                {
                    BuildingInterface building = hit.collider.GetComponent<BuildingInterface>();
                    if (building != null)
                    {
                        building.AssignWorker(selectedUnit);
                    }
                }
                else
                {
                    selectedUnit.MoveTo(point);
                }
            }

            float lastInputX = Input.GetAxis("Horizontal");
            float lastInputY = Input.GetAxis("Vertical");
            if (lastInputX != 0f || lastInputY != 0f)
            {
                movement = new Vector3(lastInputX, lastInputY, 0) + mainCamera.transform.position;
                mainCamera.transform.position = Vector3.Lerp(mainCamera.transform.position, movement, speed * Time.deltaTime);
            }
        }
    }
}
