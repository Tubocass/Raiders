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

    public event Alarm NoLongerFleeing;
	public State_Flee(NpcBase unit, LayerMask m)
	{
		NpcController = unit;
		mask = m;
	}
	public void EnterState()
	{
        alertRaised = true;
		safeSpaces = NpcBase.FindTargets<Safety>("Safety",NpcController.Location,100f, mask, s=> s.isOpen);
        if(safeSpaces.Count>0)
        safeHouse = NpcBase.TargetNearest<Safety>(NpcController.Location, safeSpaces).transform;
    }
	public void ExitState(){}
//	public void Animate();
	public void AssesSituation()
	{
		UnitController targetEnemy = NpcController.NearestEnemy();
		
		if(targetEnemy !=null)
		{
			Vector3 enemyVector = targetEnemy.Location-NpcController.Location;
			Vector3 homeVector = safeHouse.position-NpcController.Location;

			//if(enemyVector.magnitude<=10)
			if(enemyVector.magnitude<homeVector.magnitude/2)
			{
				movement = -enemyVector.normalized;
				animSpeed = 1f;
				NpcController.mover.Move(movement);
				bMovingToSafety = false;
				beingChased = true;
			}else beingChased = false;
		}
		if(!beingChased && !bMovingToSafety)
		{
			//safeHouse = NpcBase.TargetNearest<Safety>(NpcController.Location,safeSpaces).transform;
			RunToSafety();
		}
		if(bMovingToSafety)
		{
			if(Vector3.Distance(NpcController.Location,safeHouse.position)>=1f)
			{
				RunToSafety();
			}else{
				animSpeed = 0f;
				bMovingToSafety = false;
                safeHouse.GetComponent<Safety>().EnterSafety(this.NpcController);
                if (NoLongerFleeing != null)
                {
                    NoLongerFleeing();
                }
                NpcController.gameObject.SetActive(false);

			}
		}
	}
	void RunToSafety()
	{
        if (safeSpaces.Count > 0)
            safeHouse = NpcBase.TargetNearest<Safety>(NpcController.Location, safeSpaces).transform;
        if (safeHouse !=null)
		{
			movement = (safeHouse.position-NpcController.Location).normalized;
			animSpeed = 1f;
			NpcController.mover.MoveTo(safeHouse.position);
			bMovingToSafety = true;
		}
	}

}
