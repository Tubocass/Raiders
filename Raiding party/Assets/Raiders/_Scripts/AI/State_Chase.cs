using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State_Chase : IBehaviourState 
{
	NpcBase NpcController;
	LayerMask mask;
	UnitController targetEnemy;
	Vector3 movement;
	protected bool canAttack = true;
	public State_Chase(NpcBase npc, UnitController target)
	{
		NpcController = npc;
		targetEnemy = target;
	}
	public void EnterState()
	{
		Debug.Log("Entering Chase");
//		NpcController.enemies = NpcBase.FindTargets<UnitController>("Unit", NpcController.Location, 50f, mask, ot=> ot!=null && !ot.teamID.Equals(teamID));
//		NpcBase targetEnemy = NpcBase.TargetNearest<UnitController>(NpcController.Location, NpcController.enemies);
	}
	public void ExitState()
	{
		Debug.Log("Exiting Chase");
	}
//	public void Animate();
	public void AssesSituation()
	{
		if(targetEnemy!=null)
		{
			if(Vector3.Distance(NpcController.Location,targetEnemy.Location)>1.25f)//Am I going somewhere
			{
				movement = (targetEnemy.Location-NpcController.Location).normalized;
				NpcController.Animate(movement, 1f);
				NpcController.mover.MoveTo(targetEnemy.Location);
			}else 
			{
				Vector3 enemyVector = targetEnemy.Location-NpcController.Location;
				
				if(Vector3.Dot(enemyVector,movement)>0)//am I facing the enemy
				{
					NpcController.Attack(enemyVector);
				}
				NpcController.Animate(movement, 0f);
			}
		}
	}


}
