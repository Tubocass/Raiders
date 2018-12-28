using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class GUIController : MonoBehaviour
{
    [SerializeField] LayerMask mask;
    [SerializeField] GameObject panelFab;
    [SerializeField] Canvas canvas;
    PanelController panel;
    [SerializeField] GameObject raidPanel;
    RaidPrompt raidPrompt;
    TownInfo currentTown;
    // Start is called before the first frame update
    void Start()
    {
        GameObject raidUI = Instantiate(raidPanel, Vector3.zero, Quaternion.identity);
        raidUI.transform.SetParent(canvas.transform, false);
        raidPrompt = raidUI.GetComponent<RaidPrompt>();
        raidPrompt.HidePanel();
        GameObject panelUI = Instantiate(panelFab, Vector3.zero, Quaternion.identity);
        panelUI.transform.SetParent(canvas.transform, false);
        panelUI.transform.SetAsLastSibling();
        panel = panelUI.GetComponent<PanelController>();
        panel.HidePanel();
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
                currentTown = hit.transform.GetComponent<TownInfo>();
                Vector3 loc = Camera.main.WorldToScreenPoint(hit.point);
                //Debug.Log("HIT!");
                panel.SetInfo(currentTown.DisplayInfo());
                panel.SetButton(() => 
                {
                    SetupRaid();
                    panel.HidePanel();
                });
                panel.ShowPanel(loc);
            }

        }
    }
    public void SetupRaid()
    {
        raidPrompt.ShowPanel(Camera.main.WorldToScreenPoint(currentTown.location));
    }
}
