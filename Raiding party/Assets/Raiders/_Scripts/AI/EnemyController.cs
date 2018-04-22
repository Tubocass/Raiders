using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.Events;
using UnityEngine.AI;

public class EnemyController : NpcBase 
{
	[SerializeField] GameObject weapon;
	State_Chase chaseState;
	State_Follow followState;
	State_Idle idleState;

	protected override void OnEnable()
	{
		base.OnEnable();
		UnityEventManager.StartListeningInt("TargetUnavailable", TargetLost);
	}
	protected override void OnDisable()
	{
		base.OnDisable();
		UnityEventManager.StopListeningInt("TargetUnavailable", TargetLost);
	}
	protected override void Start()
	{
		base.Start();
		canPickupTreasure = true;
		followState = new State_Follow(this, Leader);
		idleState = new State_Idle(this);
		idleState.TargetSpotted += DecisionTree;
		if(isFollowing)
		{
			FollowLeader();
		}else
		{
			BehaviourState = idleState;
			pursuitRange = 50f;
		}
	}

	public override void Update()
	{
		/*Follow Leader
		 * 		stick close to leader (don't chase x distance away)
		 * 		Kill anything immediately around
		 * 		Assist in anything the leader does
		 * Berserk
		 * 		Kill anything immediately around
		 * 		Look for and chase down enemies
		 * 
		 */
	
		base.Update();
//		if(target!=null && Vector3.Distance(Location,target.position)>1f)//Am I going somewhere
//		{
//			movement = (target.position-Location).normalized;
//			animSpeed = 1f;
//			//agent.destination = target.position;
//			mover.Move(movement);
//		}else{//we don't have a target, or we've arrived
//			animSpeed = 0f;
//			if(IsTargetingEnemy())
//			{
//				Vector3 enemyVector = targetEnemy.Location-Location;
//
//				if(Vector3.Dot(enemyVector,movement)>0)//am I facing the enemy
//				{
//					if(canAttack)
//					{
//						Attack();
//					}
//				}else{
//					//mover.Move(enemyVector);
//				}
//			}else 

		BehaviourState.AssesSituation();
		//Animate();
	}
	public void DecisionTree()
	{
		if(allowedToFight)
		{
			targetEnemy = NearestEnemy();
			if(targetEnemy!=null)
			{
				chaseState = new State_Chase(this, targetEnemy);
				BehaviourState = chaseState;
				return;
			}
		}
		if(Leader != null && Leader.isActive)
		{
			FollowLeader();//Can't find any targets, follow the Leader
		}else 
		{
			BehaviourState = idleState;
			pursuitRange = 50f;
		}
	}
	void FollowLeader()
	{
		if(Leader != null && Leader.isActive)
		{
			isFollowing = true;
			pursuitRange = 20f;
			BehaviourState = followState;
		}
	}
//	protected bool IsTargetingEnemy()
//	{
//		if(targetEnemy!=null && targetEnemy.isActive)
//			return true;
//		else return false;
//	}
	protected void TargetLost(int id)
	{
		if(targetEnemy!=null && id == targetEnemy.unitID)
		{
			DecisionTree();
		}
	}

	protected override void OnTriggerEnter(Collider bam)
	{
		base.OnTriggerEnter(bam);
	}
}
