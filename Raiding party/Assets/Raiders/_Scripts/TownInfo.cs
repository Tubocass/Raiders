using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TownInfo : MonoBehaviour
{
    public string townName;
    public float foodSupply, woodSupply, treasureSupply;
    public int population, troopCount, townLevel;
    public int foodslots, materialSlots, craftSlots;
    List<ProductionSource> sources = new List<ProductionSource>();

    public string getTownInfo()
    {
        return string.Format("townName: {0}, food: {1}", this.townName, this.foodSupply);
    }
    public List<ProductionSource> getProductionSources()
    {
        return sources;
    }
    
    private void Start() {
        sources.Add(new ProductionSource(ProductionSource.Resource.Food, 1));
    }
    // public void changeFoodSupply(float amount)
    // {
    //     foodSupply += amount;
    // }
    // public void changeWoodSupply(float amount)
    // {
    //     woodSupply += amount;
    // }
    // public void changeTreasureSupply(float amount)
    // {
    //     treasureSupply += amount;
    // }
    // public void changeTroopCount(int amount)
    // {
    //     troopCount += amount;
    // }
    
}
