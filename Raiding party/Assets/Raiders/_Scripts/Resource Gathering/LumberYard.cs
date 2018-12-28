using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LumberYard : ProductionSource
{
    
    void Start()
    {
        resource = Resource.Wood;
        workerCapacity = 4;
        activeWorkers = 0;
    }

    public void Setup(GameController gc)
    {
        stockpile = gc;
    }

    // Update is called once per frame
    public override void Produce()
    {
        //stockpile.changeWoodSupply((activeWorkers * productionRate * Time.deltaTime));
    }
}
