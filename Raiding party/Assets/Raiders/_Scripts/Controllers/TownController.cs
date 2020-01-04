using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TownController : MonoBehaviour
{
    public TownInfo townInfo;
    public ProductionSource[] foodSources;
    public ProductionSource[] materialSources;
    public ProductionSource[] craftSources;
    // Start is called before the first frame update
    void Start()
    {
        this.foodSources = new ProductionSource[this.townInfo.foodslots];
        this.materialSources = new ProductionSource[this.townInfo.materialSlots];
        this.craftSources = new ProductionSource[this.townInfo.craftSlots];
        for(int i = 0; i<this.townInfo.foodslots; i++)
        {
            this.foodSources[i] = new ProductionSource(ProductionSource.Resource.Food);
        }
        this.foodSources[0].build(1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public string getTownInfo()
    {
        return string.Format("townName: {0}, food: {1}", this.townInfo.townName, this.townInfo.foodSupply);
    }
    public ProductionSource[] getBuildings()
    {
        return this.foodSources;
    }
}
