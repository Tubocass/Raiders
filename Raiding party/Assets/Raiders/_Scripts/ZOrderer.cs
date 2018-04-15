using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZOrderer : MonoBehaviour 
{
	[SerializeField] Transform Top, Bottom;
	static float yMax, yMin;

	void Start () 
	{
		yMax = Top.position.z;
		yMin = Bottom.position.z;
	}

	public static float NormalHeight(float yPos)
	{
		float z = (yPos-yMin)/(yMax-yMin);
		return z;
	}
}
