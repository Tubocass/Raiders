using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProductionSource
{
    public enum Resource {Food, Material, Craft};
    public Resource resourceType = new Resource();
    public bool isActive = false;
    public float productionRate = 1.0f;
   
    public ProductionSource(Resource type)
    {
       resourceType = type;
    }
    public void build(float rate)
    {
        productionRate = rate;
        this.isActive = true;
    }
}
