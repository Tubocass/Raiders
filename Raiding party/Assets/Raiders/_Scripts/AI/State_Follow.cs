using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State_Follow : IBehaviourState
{
	NpcBase	NpcController;
	UnitController leader;
	Vector3 movement;

	public State_Follow(NpcBase npc, UnitController captain)
	{
		leader = captain;
		NpcController = npc;
	}
	public void EnterState()
	{
		
	}
	public void ExitState(){}
//	public void Animate();
	public void AssesSituation()
	{
		if(leader!=null)
		{
			if(Vector3.Distance(NpcController.Location,leader.Location)>=1.5f)//Am I going somewhere
			{
				movement = (leader.Location-NpcController.Location).normalized;
				NpcController.Animate(movement, 1f);
				//agent.destination = target.position;
				NpcController.mover.Move(movement);
			}else NpcController.Animate(movement, 0f);
		}
	}
}
