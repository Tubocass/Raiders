using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmyManagement : MonoBehaviour
{
    public int armySize;
    [SerializeField]
    Army army;
    [SerializeField]
    Leader leader;
   

    // Use this for initialization
    void Start ()
    {
        armySize = army.totalUnits;
        leader = army.currentLeader;
    }
	
	// Update is called once per frame
	void Update ()
    {
		
	}
}
