using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;

public class PanelController : MonoBehaviour 
{
    //[SerializeField] Button buttFab;
    //List <Button> buttons;
    //int buttCount = 0;
    Button myButton;
    //RectTransform rectTran;
    Text infoText;
	
	void OnEnable()
	{
		//rectTran = transform as RectTransform;
		//buttons = new List<Button>();
        infoText = GetComponentInChildren<Text>();
        myButton = GetComponentInChildren<Button>();
    }

	public void ShowPanel(Vector3 loc)
	{
		transform.position = loc;
		this.gameObject.SetActive(true);
	}

    public virtual void SetInfo(string arg)
    {
        infoText.text = arg;
    }

    public void SetButton(UnityAction action)
    {
        myButton.onClick.AddListener(action);
    }

    public void HidePanel()
    {
        this.gameObject.SetActive(false);
    }

        /* System for adding a variable amount of buttons to an otherwise blank panel with attached layout controller
        public void HidePanel()
        {
            buttCount=0;
            if(buttons.Count>0)
            {
                foreach(Button b in buttons)
                {
                    b.onClick.RemoveAllListeners();
                    b.GetComponentInChildren<Text> ().text = "";
                    b.gameObject.SetActive(false);
                }
            }
            this.gameObject.SetActive(false);
        }

        public Button AddButton(string name, bool StayInWorlPosition)
        {
            buttCount++;
            rectTran.SetSizeWithCurrentAnchors (RectTransform.Axis.Horizontal, 50 * buttCount);
            if(buttons.Count>0&& !buttons[buttons.Count-1].gameObject.activeSelf)
            {
                //turn on button
                buttons[buttons.Count-1].gameObject.SetActive(true);
                buttons[buttons.Count-1].GetComponentInChildren<Text> ().text = name;
            }else{
                Button newButton = GameObject.Instantiate (buttFab) as Button;
                newButton.transform.SetParent (rectTran, false);
                newButton.GetComponentInChildren<Text> ().text = name;
                buttons.Add(newButton);
            }
            return buttons[buttons.Count-1];

        }
        */
    }
