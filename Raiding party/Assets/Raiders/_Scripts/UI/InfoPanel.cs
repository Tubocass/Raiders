using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InfoPanel : MonoBehaviour
{
    [SerializeField]
    GameController gc;
    Text text;
    // Start is called before the first frame update
    void Start()
    {
        text = GetComponentInChildren<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        //text.text = "Population: " + (int)gc.population
        //   + "\nFood Supply: " + (int) gc.foodSupply
        //   + "\nWood Supply: " + (int) gc.woodSupply
        //   + "\nTreasure  Supply: " + gc.treasureSupply
        //   + "\nTroops: " + gc.troopCount;
    }
}
