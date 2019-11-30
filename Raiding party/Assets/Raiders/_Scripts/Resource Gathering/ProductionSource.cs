using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProductionSource
{
    public enum Resource {Food, Wood, Gold, Weapon};
    public Resource resourceType = new Resource();
    // protected GameController stockpile;
    public bool isActive = true;
    public float productionRate = 1.0f;
    // protected int workerCapacity = 1, activeWorkers = 0;
    // public bool isAtCapacity = false;
   
    public ProductionSource(Resource type, float rate)
    {
       resourceType = type;
       productionRate = rate;
       
    }

    // public bool AddWorker()
    // {
    //     if(activeWorkers>=workerCapacity)
    //     {
    //         return false;
    //     } else
    //     {
    //         activeWorkers += 1;
    //         if (activeWorkers >= workerCapacity)
    //             isAtCapacity = true;
    //         return true;
    //     }
    // }
    // public virtual void Produce( )
    // {
       
    // }
}
