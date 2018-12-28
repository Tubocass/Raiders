using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RaidPrompt : PanelController
{
    int count = 0;
    float distanceToTarget = 2;
    float suppliesNecessary = 1;
    [SerializeField] Text counterText;
    //Location targetLocation

    private float CalcCost()
    {
        return count * distanceToTarget * suppliesNecessary;
    }

    public void Increase()
    {
        count++;
        counterText.text = ""+count;
    }
    public void Decrease()
    {
        count--;
        counterText.text = ""+count;
    }

    public void Submit()
    {
        Debug.Log("Attacking with "+count+" men will cost " + CalcCost() + " food");
    }
}
