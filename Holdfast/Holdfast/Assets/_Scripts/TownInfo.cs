using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/TownInfo", order = 1)]
public class TownInfo: ScriptableObject
{
    [SerializeField] string townName;
    [SerializeField] int population, gold, food;
    Dictionary<string,string> keyValues = new Dictionary<string, string>();

    public Dictionary<string, string> getTownInfo()
    {
        keyValues.Add("townName", this.townName);
        keyValues.Add("population", this.population.ToString());
        keyValues.Add("gold", this.gold.ToString());
        keyValues.Add("food", this.food.ToString());

        return keyValues;
    }
}
