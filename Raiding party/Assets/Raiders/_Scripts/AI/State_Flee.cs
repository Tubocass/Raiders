using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State_Flee : IBehaviourState
{
	NpcBase NpcController;
	List<Safety> safeSpaces;
	Transform safeHouse;
	LayerMask mask;
	bool alertRaised, bMovingToSafety, beingChased;
	Vector3 movement;
	float animSpeed;
	public State_Flee(NpcBase unit, LayerMask m)
	{
		NpcController = unit;
		mask = m;
	}
	public void EnterState()
	{
		alertRaised = true;
		safeSpaces = NpcBase.FindTargets<Safety>("Safety",NpcController.Location,100f, mask, s=> s.isOpen);
	}
	public void ExitState(){}
//	public void Animate();
	public void AssesSituation()
	{
		UnitController targetEnemy = NpcController.NearbyEnemy();
		if(alertRaised)
		{
			if(targetEnemy !=null)
			{
				Vector3 enemyVector = targetEnemy.Location-NpcController.Location;
				if(enemyVector.magnitude<10)
				{
					movement = -enemyVector.normalized;
					animSpeed = 1f;
					NpcController.mover.Move(movement);
					bMovingToSafety = false;
					beingChased = true;
					Debug.Log("Running Away");
				}else beingChased = false;
			}
			if(!beingChased && !bMovingToSafety)
			{
				safeHouse = NpcBase.TargetNearest<Safety>(NpcController.Location,safeSpaces).transform;
				RunToSafety();
				Debug.Log("Going Home");
			}
			if(bMovingToSafety)
			{
				if(Vector3.Distance(NpcController.Location,safeHouse.position)>1f)
				{
					RunToSafety();
					Debug.Log("Running Home");
				}else{
					animSpeed = 0f;
					bMovingToSafety = false;
					Debug.Log("At Home");
				}
			}
		}else if(targetEnemy !=null)
		{
			Debug.Log("Alert!");
		}
			
	}
	void RunToSafety()
	{
		if(safeHouse !=null)
		{
			movement = (safeHouse.position-NpcController.Location).normalized;
			animSpeed = 1f;
			NpcController.mover.Move(movement);
			bMovingToSafety = true;
		}
	}

}
