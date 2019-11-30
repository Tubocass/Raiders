using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceManager : MonoBehaviour
{
    //Supply Controls -------------------------------------------------------------
    public float foodSupply, woodSupply, treasureSupply;
    public int population, troopCount;

    [SerializeField]
    float gatherRate;

    public void changeFoodSupply(float amount)
    {
        foodSupply += amount;
    }
    public void changeWoodSupply(float amount)
    {
        woodSupply += amount;
    }
    public void changeTreasureSupply(float amount)
    {
        treasureSupply += amount;
    }
    public void changeTroopCount(int amount)
    {
        troopCount += amount;
    }

    //Supply Controls -------------------------------------------------------------

    List<ProductionSource> sources = new List<ProductionSource>();
    [SerializeField] GameObject lumberFab, farmFab;
    // Coroutines
 

}
