using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TownInfo : MonoBehaviour
{
    public string townName;
    public string townWealth;
    public string townLevel;
    public Vector3 location;

    private void Start()
    {
        location = transform.position;
    }
    public string DisplayInfo()
    {

        return string.Format("Village of: {0} \n Wealth: {1} \n Level: {2}", townName, townWealth, townLevel);
    }
}
