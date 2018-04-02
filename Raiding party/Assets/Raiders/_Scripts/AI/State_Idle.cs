using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void Alarm();
public class State_Idle : IBehaviourState
{
	NpcBase NpcController;
	public event Alarm TargetSpotted;

	public State_Idle(NpcBase unit)
	{
		NpcController = unit;
	}
	public void EnterState(){}
	public void ExitState(){}
	//	public void Animate();
	public void AssesSituation()
	{
		UnitController targetEnemy = NpcController.NearestEnemy();
		if(targetEnemy != null)
		{
			//Debug.Log("Alarm");
			if(TargetSpotted!=null)
			{
				TargetSpotted();
			}
			//UnityEventManager.TriggerEvent("AlarmEvent");
		}
	}
}
