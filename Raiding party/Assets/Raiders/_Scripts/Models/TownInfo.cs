[System.Serializable]
public class TownInfo
{
    public string townName;
    public float foodSupply, woodSupply, treasureSupply;
    public int population, troopCount, townLevel;
    public int foodslots, materialSlots, craftSlots;
    public ProductionSource[] foodSources;
    public ProductionSource[] materialSources;
    public ProductionSource[] craftSources;

}
