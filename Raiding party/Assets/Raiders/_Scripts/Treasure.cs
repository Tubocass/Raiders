using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Treasure : MonoBehaviour, IPickup 
{
	public int Value{get{return value;}}
	[SerializeField] int value;
	public void Pickup(Transform holder)
	{
		//update amount of treasure, or be carried off and counted upon collection
		//UnityEventManager.TriggerEvent("TreasureEvent",value);
		transform.SetParent(holder);
		transform.localPosition = Vector3.up;
	}
	public void PutDown()
	{
		transform.SetParent(null);
		Destroy(gameObject);
	}

}
