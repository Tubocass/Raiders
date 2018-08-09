using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Treasure : MonoBehaviour, IPickup 
{
	public int Value{get{return value;}}
	public bool IsAvailable{get{return isAvailable;}}
	[SerializeField] int value;
	bool isAvailable = true;
	public void Pickup(Transform holder)
	{
		//update amount of treasure, or be carried off and counted upon collection
		//UnityEventManager.TriggerEvent("TreasureEvent",value);
		transform.SetParent(holder);
		transform.localPosition = Vector3.forward;
		isAvailable = false;
	}
	public void PutDown()
	{
		transform.SetParent(null);
		Destroy(gameObject);
	}

}
