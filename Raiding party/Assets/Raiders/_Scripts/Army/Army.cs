using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Army
{
    /*
     * represents the units under the command of one of your captains/lieutenants
     * as well as their supply levels 
     */
    public Leader currentLeader;
    public string armyName;
    public int supplyLevel;
    public int lightInfantry;
    public int veteranInfantry;
    public int skirmishers;
    public int mountedWarriors;
    public int totalUnits { get { return 1 + lightInfantry + veteranInfantry + skirmishers + mountedWarriors; } }

}

[System.Serializable]
public class Leader
{
    public string leaderName;
    /*
     * portrait
     * loyalty
     * */
}