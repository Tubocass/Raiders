using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProductionSource: MonoBehaviour
{
    public enum Resource {Food, Wood, Gold};
    protected Resource resource = new Resource();
    protected GameController stockpile;
    protected bool isActive = true;
    protected float productionRate = 1.0f;
    protected int workerCapacity = 1, activeWorkers = 0;
    public bool isAtCapacity = false;
   
    //public ProductionSource(Resource type, float rate, int workerCap)
    //{
    //    resource = type;
    //    productionRate = rate;
    //    workerCapacity = workerCap;
    //}

    public bool AddWorker()
    {
        if(activeWorkers>=workerCapacity)
        {
            return false;
        } else
        {
            activeWorkers += 1;
            if (activeWorkers >= workerCapacity)
                isAtCapacity = true;
            return true;
        }
    }
    public virtual void Produce( )
    {
       
    }
}
