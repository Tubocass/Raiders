using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Treasure : MonoBehaviour, IPickup 
{
	[SerializeField] int value;
	public void Pickup()
	{
		//update amount of treasure, or be carried off and counted upon collection
		UnityEventManager.TriggerEvent("TreasureEvent",value);

	}

}
