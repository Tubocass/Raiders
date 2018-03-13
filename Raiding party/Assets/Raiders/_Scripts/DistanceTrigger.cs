using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistanceTrigger : MonoBehaviour 
{
	Vector3 Location{get{return transform.position;}}

	void Start()
	{
		transform.position = new Vector3(Location.x,Location.y,ZOrderer.NormalZ(Location.y));
	}


}
