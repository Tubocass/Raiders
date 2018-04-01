using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeasantAI : NpcBase
{
	public bool alertRaised, spotEnemy;
	State_Flee fleeState;
	State_Idle idleState;
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
		fleeState = new State_Flee(this, mask);
		idleState = new State_Idle(this);
		BehaviourState = fleeState;
		//target = GameObject.FindGameObjectWithTag("Player").transform;
	}

	public override void Update()
	{
		base.Update();
		BehaviourState.AssesSituation();
		Animate();
	}

//	void AsessSituation()
//	{
//		/*	Behaviors:
//	 * 		Mill about
//	 * 			Move between a couple of waypoints, animatiting different activities
//	 * 		Raise Alarm
//	 * 			Move to Sound Alarm
//	 * 		Flee
//	 * 			Run away from immediate threats
//	 * 			seek shelter
//	 */
//		if(alertRaised)
//		{
//			List<Safety> safeSpaces = FindTargets<Safety>("Safety",Location,50f, mask, s=> s.isOpen);
//			Transform safeHouse = TargetNearest<Safety>(Location,safeSpaces).transform;
//			if(safeHouse !=null)
//			{
//				movement = (safeHouse.position-Location).normalized;
//				animSpeed = 1f;
//				//agent.destination = target.position;
//				mover.Move(movement);
//			}
////			enemies = FindTargets<UnitController>("Unit", u=> !u.teamID.Equals(teamID));
////			targetEnemy = TargetNearest<UnitController>(enemies);
////			if(targetEnemy!=null)
////			{
////				Vector3 enemyVector = targetEnemy.Location-Location;
////				if(Vector3.Distance(Location, targetEnemy.Location)<20)
////				{
////					movement = -enemyVector.normalized;
////					animSpeed = 1f;
////					mover.Move(movement);
////				}
////			}
////			if(currentState!= Behaviour.Flee)
////			currentState = Behaviour.Flee;
//		}
//	}
}
