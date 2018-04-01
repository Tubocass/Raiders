using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State_Idle : IBehaviourState
{
	UnitController NpcController;
	public State_Idle(UnitController unit)
	{
		NpcController = unit;
	}
	public void EnterState(){}
	public void ExitState(){}
	//	public void Animate();
	public void AssesSituation()
	{
		
	}
}
