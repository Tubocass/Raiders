using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State_Idle : IBehaviourState
{
	NpcBase NpcController;
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
			Debug.Log("Alarm");
			UnityEventManager.TriggerEvent("AlarmEvent");
		}
	}
}
