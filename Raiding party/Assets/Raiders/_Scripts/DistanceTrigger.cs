using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistanceTrigger : MonoBehaviour 
{
	Vector3 Location{get{return transform.position;}}
	[SerializeField] protected float distToFeet = 0.35f;

	void Start()
	{
		transform.position = new Vector3(Location.x,Location.y,ZOrderer.NormalZ(Location.y-distToFeet));
	}


}
