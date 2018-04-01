using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.Events;
using UnityEngine.AI;

public class EnemyController : NpcBase 
{
	[SerializeField] GameObject weapon;
	bool bCarryingTreasure = false;
	Treasure carriedTreasure;

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
		enemies = FindTargets<UnitController>("Unit",Location,50f,mask, ot=> ot!=null && !ot.teamID.Equals(teamID));
		targetEnemy = TargetNearest<UnitController>(Location,enemies);
		if(targetEnemy!=null)
			target = targetEnemy.transform;
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
		if(target!=null && Vector3.Distance(Location,target.position)>1f)//Am I going somewhere
		{
			movement = (target.position-Location).normalized;
			animSpeed = 1f;
			//agent.destination = target.position;
			mover.Move(movement);
		}else{//we don't have a target, or we've arrived
			animSpeed = 0f;
			if(IsTargetingEnemy())
			{
				Vector3 enemyVector = targetEnemy.Location-Location;

				if(Vector3.Dot(enemyVector,movement)>0)//am I facing the enemy
				{
					if(canAttack)
					{
						Attack();
					}
				}else{
					//mover.Move(enemyVector);
				}
			}else if(allowedToFight)
				{
				enemies = FindTargets<UnitController>("Unit",Location,50f,mask, ot=> ot!=null && !ot.teamID.Equals(teamID));
				targetEnemy = TargetNearest<UnitController>(Location,enemies);
					//targetEnemy = TargetNearest(FindTargets("Unit"));
				if(targetEnemy!=null)
					target = targetEnemy.transform;
				else
					FollowLeader();//Can't find any targets, follow the Leader
				}
			}
			
		Animate();
	}
	void FollowLeader()
	{
		if(Leader != null && Leader.isActive)
		{
			isFollowing = true;
			target = Leader.transform;
		}
	}

	protected override void OnTriggerEnter2D(Collider2D bam)
	{
		base.OnTriggerEnter2D(bam);
		if(bam.CompareTag("Treasure")&& !bCarryingTreasure)
		{
			Treasure pickup = bam.GetComponent<Treasure>();//treasure implements IPickup
			pickup.Pickup(transform);
			bCarryingTreasure = true;
			carriedTreasure = pickup;
			//bam.gameObject.SetActive(false);
		}
		if(bam.CompareTag("Capture") && bCarryingTreasure)
		{
			UnityEventManager.TriggerEvent("TreasureEvent", carriedTreasure.Value);
			bCarryingTreasure = false;
			carriedTreasure.PutDown();
			carriedTreasure = null;
		}
	}
}
