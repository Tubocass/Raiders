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
    private void Start()
    {
        StartCoroutine(GattherSupplies());
    }

    public void CreateLumberMill()
    {
        GameObject lm = Instantiate(lumberFab, Vector3.zero, Quaternion.identity);
        LumberYard yard = lm.GetComponent<LumberYard>();
        //yard.Setup(this);
        sources.Add(yard);
    }

    public void AddWorker()
    {
        if (sources.Count > 0)
        {
            ProductionSource s = sources.Find(p => !p.isAtCapacity);
            if (s != null)
                s.AddWorker();
        }
    }

    IEnumerator GattherSupplies()
    {
        while (true)
        {
            yield return null;
            for (int r = 0; r < sources.Count; r++)
            {
                sources[r].Produce();
            }
        }
    }
}
