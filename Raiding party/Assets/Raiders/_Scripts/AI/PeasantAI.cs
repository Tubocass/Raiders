using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeasantAI : NpcBase
{
	/*	Behaviors:
	 * 		Mill about
	 * 		Raise Alarm
	 * 		Flee
	 */
//	private enum Behaviour{Flee, Work, Alert}
//	Behaviour currentState;

	List<UnitController> enemies = new List<UnitController>();
	public bool alertRaised, spotEnemy;

	protected override void OnEnable()
	{
		base.OnEnable();
		//UnityEventManager.StartListeningInt("TargetUnavailable", TargetLost);
	}
	protected override void OnDisable()
	{
		base.OnDisable();
		//UnityEventManager.StopListeningInt("TargetUnavailable", TargetLost);
	}
	protected override void Start()
	{
		base.Start();
		//target = GameObject.FindGameObjectWithTag("Player").transform;
	}

	public override void Update()
	{
		base.Update();
		if(target!=null && Vector3.Distance(Location,target.position)>1f)//Am I going somewhere
		{
			movement = (target.position-Location).normalized;
			animSpeed = 1f;
			mover.Move(movement);
		}else{
			animSpeed = 0f;
		}
		AsessSituation();
	}
//	UnitController TargetNearest()
//	{
//		float nearestEnemyDist, newDist;
//		UnitController enemy = null;
//
//		Collider2D[] cols = Physics2D.OverlapCircleAll(transform.position,50,mask);
//		if(cols.Length>0)
//		{
//			for(int f = 0; f<cols.Length-1;f++)
//			{
//				if(cols[f].CompareTag("Unit"))
//				{
//					UnitController ot = cols[f].GetComponent<UnitController>();
//					if(ot!=null && !ot.teamID.Equals(teamID) && !enemies.Contains(ot))
//					{
//						enemies.Add(ot);
//					}
//				}
//			}
//		}
//		if(enemies.Count>0)
//		{
//			nearestEnemyDist = (enemies[0].Location-Location).sqrMagnitude; //Vector3.Distance(Location,enemies[0].Location);
//			for(int f = 0; f<enemies.Count;f++)
//			{
//				if(enemies[f].isActive)
//				{
//					newDist = (enemies[f].Location-Location).sqrMagnitude;//Vector3.Distance(Location,unit.Location);
//					if(newDist <= nearestEnemyDist)
//					{
//						nearestEnemyDist = newDist;
//						enemy = enemies[f];
//					}
//				}
//			}
//		}
//
//		return enemy;
//	}
	void AsessSituation()
	{
		if(alertRaised)
		{
			List<Safety> safeSpaces = FindTargets<Safety>("Safety", s=> s.isOpen);
			Transform safeHouse = TargetNearest<Safety>(safeSpaces).transform;
			if(safeHouse !=null)
			{
				movement = (safeHouse.position-Location).normalized;
				animSpeed = 1f;
				//agent.destination = target.position;
				mover.Move(movement);
			}
//			enemies = FindTargets<UnitController>("Unit", u=> !u.teamID.Equals(teamID));
//			targetEnemy = TargetNearest<UnitController>(enemies);
//			if(targetEnemy!=null)
//			{
//				Vector3 enemyVector = targetEnemy.Location-Location;
//				if(Vector3.Distance(Location, targetEnemy.Location)<20)
//				{
//					movement = -enemyVector.normalized;
//					animSpeed = 1f;
//					mover.Move(movement);
//				}
//			}
//			if(currentState!= Behaviour.Flee)
//			currentState = Behaviour.Flee;
		}
	}
}
